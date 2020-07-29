using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using DependencyMapper.GraphViz;
using DependencyMapper.Mapping;
using DependencyMapper.Ui;

namespace DependencyMapper
{
  public partial class MainForm : Form
  {
    private const string GraphVizPathEnvironmentVariableName = "GraphVizBinPath";
    private const string NodesListCategoryFilterAll = "[ALL]";
    private const string UnknownCategory = "unknown";
    private const string DefaultCategory = "Default";

    private INodeDependencyMapper _dependencyMapper = NodeDependencyMapper.Instantiate();
    private string _saveFilename;

    private Dictionary<string, Color> _diagramNodeColourByCategory = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
    {
      { "input", Color.FromArgb(100, 180, 255) },
      { "output", Color.FromArgb(180, 255, 180) },
      { "subsystem", Color.FromArgb(255, 180, 180) },
      { "sound", Color.FromArgb(255, 255, 180) },
      { "gfx", Color.FromArgb(180, 255, 255) },
      { UnknownCategory, Color.FromArgb(255, 100, 255) }
    };

    private Dictionary<string, GraphVizDiagram.Node.NodeShape> _diagramNodeShapeByCategory = new Dictionary<string, GraphVizDiagram.Node.NodeShape>(StringComparer.OrdinalIgnoreCase)
    {
      { "input", GraphVizDiagram.Node.NodeShape.BOX },
      { "output", GraphVizDiagram.Node.NodeShape.BOX },
      { "subsystem", GraphVizDiagram.Node.NodeShape.BOX },
      { "sound", GraphVizDiagram.Node.NodeShape.OCTAGON },
      { "gfx", GraphVizDiagram.Node.NodeShape.OCTAGON },
      { UnknownCategory, GraphVizDiagram.Node.NodeShape.BOX }
    };

    public MainForm()
    {
      InitializeComponent();

      PopulateNodeListCategoryFilters();
    }

    private void newNodeBtn_Click(object sender, EventArgs e)
    {
      INode newNode = _dependencyMapper.CreateNode();

      newNode.UpdateName("New Node");
      newNode.UpdateCategory(DefaultCategory);

      if (nodesListCategoryFilter.Text != NodesListCategoryFilterAll)
      {
        newNode.UpdateCategory(nodesListCategoryFilter.Text);
      }

      var uiNode = new NodeWrapper(newNode);

      nodesList.Items.Add(uiNode);

      nodesList.SelectedItem = uiNode;
      
      nodeNameTxtBox.Focus();
    }

    private void nodesList_SelectedIndexChanged(object sender, EventArgs e)
    {
      INode node = GetSelectedNode();

      if (node == null)
      {
        return;
      }

      nodeNameTxtBox.Text = node.Name;
      nodeDescriptionTxtBox.Text = node.Description;
      nodeCategoryDropdown.Text = node.Category;

      PopulateNodeRelationshipsList();
    }

    private void nodeSaveBtn_Click(object sender, EventArgs e)
    {
      INode node = GetSelectedNode();

      if (node == null)
      {
        MessageBox.Show(
          "Select a node first.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      string nodeName = nodeNameTxtBox.Text.Trim();
      string nodeDescription = nodeDescriptionTxtBox.Text.Trim();
      string nodeCategory = nodeCategoryDropdown.Text.Trim();

      if (string.IsNullOrWhiteSpace(nodeName))
      {
        MessageBox.Show(
          "Node must have a valid name.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      if (string.IsNullOrWhiteSpace(nodeCategory))
      {
        MessageBox.Show(
          "Node must have a valid category.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      node.UpdateName(nodeName);
      node.UpdateDescription(nodeDescription);
      node.UpdateCategory(nodeCategory);

      if (!nodeName.Contains(
        nodesListNameFilter.Text,
        StringComparison.OrdinalIgnoreCase))
      {
        nodesListNameFilter.Text = string.Empty;
      }

      Save();
      PopulateNodeListCategoryFilters();

      nodesList.Sorted = false;
      nodesList.Sorted = true;
    }

    private INode GetSelectedNode()
    {
      var uiNode = nodesList.SelectedItem as NodeWrapper;

      if (uiNode == null)
      {
        return null;
      }

      return uiNode.Node;
    }

    private void Save()
    {
      if (_saveFilename == null ||
          !File.Exists(_saveFilename))
      {
        using (var dlg = new SaveFileDialog())
        {
          dlg.Filter = "JSON | *.json";
          dlg.CheckPathExists = true;
          dlg.OverwritePrompt = true;
          dlg.ShowDialog(this);

          _saveFilename = dlg.FileName;
        }

        if (string.IsNullOrWhiteSpace(_saveFilename))
        {
          return;
        }
      }

      File.WriteAllText(
        _saveFilename,
        _dependencyMapper.Serialise());

      // Force text refresh of item in list (in case name changed).
      if (nodesList.SelectedItem != null)
      {
        nodesList.Items[nodesList.SelectedIndex] = nodesList.Items[nodesList.SelectedIndex];
      }

      if (nodeCategoryDropdown.Text.Any())
      {
        var dropdownCategories = new List<string>();

        foreach (var i in nodeCategoryDropdown.Items)
        {
          dropdownCategories.Add(i.ToString());
        }

        if (!dropdownCategories
          .Contains(
            nodeCategoryDropdown.Text,
            StringComparer.OrdinalIgnoreCase))
        {
          nodeCategoryDropdown.Items.Add(nodeCategoryDropdown.Text);
        }
      }
    }

    private void OnFileLoad(object sender, EventArgs args)
    {
      using (var dlg = new OpenFileDialog())
      {
        dlg.Filter = "JSON | *.json";
        dlg.CheckPathExists = true;
        dlg.CheckFileExists = true;
        dlg.ShowDialog(this);

        _saveFilename = dlg.FileName;
      }

      if (string.IsNullOrWhiteSpace(_saveFilename))
      {
        return;
      }

      string serialisedData = File.ReadAllText(_saveFilename);

      _dependencyMapper = NodeDependencyMapper.InstantiateFromSerialisedData(serialisedData);

      nodeCategoryDropdown
        .Items
        .AddRange(
          _dependencyMapper
            .Nodes
            .ToList()
            .Select(n => n.Category)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray());

      PopulateNodeListCategoryFilters();
      PopulateNodesList();
    }

    private void nodeRelationshipsEdit_Click(object sender, EventArgs e)
    {
      INode node = GetSelectedNode();

      if (node == null)
      {
        MessageBox.Show(
          "Select a node first.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      EditNodeRelationshipsDialog.RelationshipMode mode = nodeDependenciesBtn.Checked ?
        EditNodeRelationshipsDialog.RelationshipMode.Dependencies :
        EditNodeRelationshipsDialog.RelationshipMode.Dependants;

      using (var dlg = new EditNodeRelationshipsDialog(
        node,
        _dependencyMapper,
        mode))
      {
        dlg.ShowDialog(this);
      }

      Save();
      UpdateDiagram();
    }

    private void PopulateNodeRelationshipsList()
    {
      nodeRelationshipsList.Items.Clear();

      INode node = GetSelectedNode();

      if (node == null)
      {
        return;
      }

      if (nodeDependenciesBtn.Checked)
      {
        _dependencyMapper
          .GetDependencies(node)
          .ToList()
          .ForEach(d => nodeRelationshipsList.Items.Add(new NodeWrapper(d)));
      }
      else
      {
        _dependencyMapper
          .GetDependants(node)
          .ToList()
          .ForEach(d => nodeRelationshipsList.Items.Add(new NodeWrapper(d)));
      }
    }

    private void nodeDependenciesBtn_CheckedChanged(object sender, EventArgs e)
    {
      PopulateNodeRelationshipsList();
    }

    private void nodeDependantsBtn_CheckedChanged(object sender, EventArgs e)
    {
      PopulateNodeRelationshipsList();
    }

    private void OnDiagramGenerate(object sender, EventArgs args)
    {
      UpdateDiagram();
    }

    private void UpdateDiagram()
    {
      string graphVizBinPath = Environment.GetEnvironmentVariable(GraphVizPathEnvironmentVariableName);

      if (graphVizBinPath == null ||
        !Directory.Exists(graphVizBinPath))
      {
        MessageBox.Show(
          $"Either the environment variable \"{GraphVizPathEnvironmentVariableName}\" is missing or the path does not exist.",
          "GraphViz Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      var graphViz = new GraphVizDiagram(
        graphVizBinPath,
        @"GraphViz\DiagramTemplate.gv");

      var nodes = new List<INode>();

      foreach (var n in nodesList.Items)
      {
        nodes.Add(((NodeWrapper)n).Node);
      }

      nodes.ForEach(n =>
      {
        Color colour;
        GraphVizDiagram.Node.NodeShape shape;

        SelectColourAndShapeByCategory(
          n.Category,
          out colour,
          out shape);

        graphViz.AddNode(
          n.Id,
          n.Name,
          n.Description,
          50,
          colour,
          shape);

        _dependencyMapper
          .GetDependencies(n)
          .ToList()
          .ForEach(d => graphViz.AddLinkToNode(n.Id, d.Id));
      });

      graphViz.CreateDiagram("diagram");

      Image img;

      using (Bitmap bmp = new Bitmap(
        $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\GraphVisTmp\diagram.bmp"))
      {
        img = new Bitmap(bmp);
      }

      diagramPicBox.Image = img;
    }

    private void SelectColourAndShapeByCategory(
      in string category,
      out Color colour,
      out GraphVizDiagram.Node.NodeShape shape)
    {
      if (_diagramNodeColourByCategory.ContainsKey(category) &&
        _diagramNodeShapeByCategory.ContainsKey(category))
      {
        colour = _diagramNodeColourByCategory[category];
        shape = _diagramNodeShapeByCategory[category];

        return;
      }

      colour = _diagramNodeColourByCategory[UnknownCategory];
      shape = _diagramNodeShapeByCategory[UnknownCategory];
    }

    private void nodeNameTxtBox_Enter(object sender, EventArgs e)
    {
      nodeNameTxtBox.SelectAll();
    }

    private void nodeCategoryDropdown_Enter(object sender, EventArgs e)
    {
      nodeCategoryDropdown.SelectAll();
    }

    private void nodesListCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
      PopulateNodesList();
    }

    private void PopulateNodeListCategoryFilters()
    {
      bool selectAll = nodesListCategoryFilter.SelectedIndex == -1 ||
        nodesListCategoryFilter.Text.Equals(NodesListCategoryFilterAll, StringComparison.OrdinalIgnoreCase);

      nodesListCategoryFilter.SelectedIndexChanged -= nodesListCategoryFilter_SelectedIndexChanged;

      nodesListCategoryFilter.Items.Clear();
      nodesListCategoryFilter.Items.Add(NodesListCategoryFilterAll);

      nodesListCategoryFilter
        .Items
        .AddRange(
          _dependencyMapper
            .Nodes
            .ToList()
            .Select(n => n.Category)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray());

      if (selectAll)
      {
        nodesListCategoryFilter.Text = NodesListCategoryFilterAll;
      }

      nodesListCategoryFilter.SelectedIndexChanged += nodesListCategoryFilter_SelectedIndexChanged;
    }

    private bool IsCategoryVisibleInNodesList(in string category)
    {
      return nodesListCategoryFilter.Text.Equals(
          NodesListCategoryFilterAll,
          StringComparison.OrdinalIgnoreCase) ||
        nodesListCategoryFilter.Text.Equals(
          category,
          StringComparison.OrdinalIgnoreCase);
    }

    private void PopulateNodesList(
      in INode showNodeDependencies = null,
      in INode showNodeDependants = null)
    {
      INode previouslySelectedNode = (nodesList.SelectedItem as NodeWrapper)?.Node;

      nodesList.SelectedIndexChanged -= nodesList_SelectedIndexChanged;

      nodesList.Items.Clear();

      List<INode> nodes;

      if (showNodeDependencies != null)
      {
        nodes = new List<INode>(
          _dependencyMapper.GetDependencies(showNodeDependencies, true));

        nodes.Add(showNodeDependencies);
      }
      else if (showNodeDependants != null)
      {
        nodes = new List<INode>(
          _dependencyMapper.GetDependants(showNodeDependants, true));

        nodes.Add(showNodeDependants);
      }
      else
      {
        nodes = new List<INode>(_dependencyMapper.Nodes);
      }

      NodeWrapper nodeToSelect = null;

      foreach (var n in nodes)
      {
        if (IsCategoryVisibleInNodesList(n.Category) &&
          n.Name.Contains(nodesListNameFilter.Text, StringComparison.OrdinalIgnoreCase))
        {
          var wrappedNode = new NodeWrapper(n);

          nodesList.Items.Add(wrappedNode);

          if (n.Id == previouslySelectedNode?.Id)
          {
            nodeToSelect = wrappedNode;
          }
        }
      }

      nodesList.SelectedIndexChanged += nodesList_SelectedIndexChanged;

      if (nodeToSelect != null)
      {
        nodesList.SelectedItem = nodeToSelect;
      }

      UpdateDiagram();
    }

    private void nodesListNameFilter_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        PopulateNodesList();
      }      
    }

    private void nodesListNameFilter_Enter(object sender, EventArgs e)
    {
      nodesListNameFilter.SelectAll();
    }

    private void nodesListNameFilterClearBtn_Click(object sender, EventArgs e)
    {
      nodesListNameFilter.Text = string.Empty;

      PopulateNodesList();
    }

    private void nodesListShowSelectedNodeDependencies_Click(object sender, EventArgs e)
    {
      if (nodesListShowSelectedNodeDependencies.Text == "RESET")
      {
        nodesListShowSelectedNodeDependencies.Text = "Dependencies";
        nodesListShowSelectedNodeDependants.Text = "Dependants";

        PopulateNodesList();

        return;
      }

      INode node = GetSelectedNode();

      if (node == null)
      {
        MessageBox.Show(
          "Select a node first.",
          "No Node Selected",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information);
        return;
      }

      nodesListCategoryFilter.Text = NodesListCategoryFilterAll;
      nodesListNameFilter.Text = string.Empty;

      PopulateNodesList(node);

      nodesListShowSelectedNodeDependencies.Text = "RESET";
      nodesListShowSelectedNodeDependants.Text = "RESET";
    }

    private void nodesListShowSelectedNodeDependants_Click(object sender, EventArgs e)
    {
      if (nodesListShowSelectedNodeDependants.Text == "RESET")
      {
        nodesListShowSelectedNodeDependants.Text = "Dependants";
        nodesListShowSelectedNodeDependencies.Text = "Dependencies";

        PopulateNodesList();

        return;
      }

      INode node = GetSelectedNode();

      if (node == null)
      {
        MessageBox.Show(
          "Select a node first.",
          "No Node Selected",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information);
        return;
      }

      nodesListCategoryFilter.Text = NodesListCategoryFilterAll;
      nodesListNameFilter.Text = string.Empty;

      PopulateNodesList(null, node);

      nodesListShowSelectedNodeDependants.Text = "RESET";
      nodesListShowSelectedNodeDependencies.Text = "RESET";
    }

    private void nodeDeleteBtn_Click(object sender, EventArgs e)
    {
      INode node = GetSelectedNode();

      if (node == null)
      {
        MessageBox.Show(
          "Select a node first.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      var dependantNodesMessage = new StringBuilder(
        $"The following nodes depend on this node:{Environment.NewLine}{Environment.NewLine}");

      _dependencyMapper
        .GetDependants(node)
        .ToList()
        .ForEach(d => dependantNodesMessage.Append($"{d.Name}{Environment.NewLine}"));

      if (MessageBox.Show(
        $"Remove \"{node.Name}\"?{Environment.NewLine}{Environment.NewLine}{dependantNodesMessage}",
        "Remove Node?",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) == DialogResult.No)
      {
        return;
      }

      _dependencyMapper.RemoveNode(node.Id);

      Save();
      PopulateNodesList();
    }
  }
}
