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
    private const string NodesListCategoryFilterCustom = "[CUSTOM]";
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
      { "external", Color.FromArgb(150, 150, 150) },
      { UnknownCategory, Color.FromArgb(255, 100, 255) }
    };

    private Dictionary<string, GraphVizDiagram.Node.NodeShape> _diagramNodeShapeByCategory = new Dictionary<string, GraphVizDiagram.Node.NodeShape>(StringComparer.OrdinalIgnoreCase)
    {
      { "input", GraphVizDiagram.Node.NodeShape.BOX },
      { "output", GraphVizDiagram.Node.NodeShape.BOX },
      { "subsystem", GraphVizDiagram.Node.NodeShape.BOX },
      { "sound", GraphVizDiagram.Node.NodeShape.OCTAGON },
      { "gfx", GraphVizDiagram.Node.NodeShape.OCTAGON },
      { "external", GraphVizDiagram.Node.NodeShape.CIRCLE },
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

      if (nodesListCategoryFilter.Text != NodesListCategoryFilterAll &&
          nodesListCategoryFilter.Text != NodesListCategoryFilterCustom)
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

      string path =
        Path.GetDirectoryName(
          Assembly.GetExecutingAssembly().Location) + @"\tmp\";

      if (Directory.Exists(path) == false)
      {
        Directory.CreateDirectory(path);
      }

      CreateDiagram(
        nodesList
          .Items
          .Cast<NodeWrapper>()
          .Select(n => n.Node),
        graphVizBinPath,
        $"{path}diagram");

      Image img;

      using (Bitmap bmp = new Bitmap(
        $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\tmp\diagram.png"))
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
      string selectedFilter = nodesListCategoryFilter.Text;

      bool selectAll = nodesListCategoryFilter.SelectedIndex == -1 ||
        selectedFilter.Equals(NodesListCategoryFilterAll, StringComparison.OrdinalIgnoreCase);

      nodesListCategoryFilter.SelectedIndexChanged -= nodesListCategoryFilter_SelectedIndexChanged;

      nodesListCategoryFilter.Items.Clear();
      nodesListCategoryFilter.Items.Add(NodesListCategoryFilterAll);
      nodesListCategoryFilter.Items.Add(NodesListCategoryFilterCustom);      

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
      else
      {
        nodesListCategoryFilter.Text = selectedFilter;
      }

      nodesListCategoryFilter.SelectedIndexChanged += nodesListCategoryFilter_SelectedIndexChanged;
    }

    private bool IsCategoryVisibleInNodesList(in string category)
    {
      var categories = new List<string>
      {
        NodesListCategoryFilterAll,
        NodesListCategoryFilterCustom
      };

      if (categories.Contains(nodesListCategoryFilter.Text, StringComparer.OrdinalIgnoreCase))
      {
        return true;
      }

      return category.Equals(
        nodesListCategoryFilter.Text,
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

      IEnumerable<INode> distinctNodes = nodes.Distinct();

      NodeWrapper nodeToSelect = null;

      foreach (var n in distinctNodes)
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

      nodesListCategoryFilter.Text = NodesListCategoryFilterCustom;
      nodesListNameFilter.Text = string.Empty;

      PopulateNodesList(node);
    }

    private void nodesListShowSelectedNodeDependants_Click(object sender, EventArgs e)
    {
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

      nodesListCategoryFilter.Text = NodesListCategoryFilterCustom;
      nodesListNameFilter.Text = string.Empty;

      PopulateNodesList(null, node);
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

    private void nodeListCategoryFilterApplyAll_OnClick(object sender, EventArgs args)
    {
      nodesListCategoryFilter.Text = NodesListCategoryFilterAll;
    }

    private void nodeRelationshipsList_DoubleClick(object sender, EventArgs e)
    {
      INode node = ((NodeWrapper)nodeRelationshipsList.SelectedItem)?.Node;

      if (node == null)
      {
        return;
      }

      if (!IsCategoryVisibleInNodesList(node.Category))
      {
        nodesListCategoryFilter.SelectedItem = NodesListCategoryFilterAll;
      }

      if (!node.Name.Contains(nodesListNameFilter.Text, StringComparison.OrdinalIgnoreCase))
      {
        nodesListNameFilter.Text = string.Empty;
      }

      PopulateNodesList();

      nodesList.SelectedItem =
        nodesList
          .Items
          .Cast<NodeWrapper>()
          .FirstOrDefault(i => i.Node.Id == node.Id);
    }

    private void copyNodeBtn_Click(object sender, EventArgs e)
    {
      INode selectedNode = GetSelectedNode();

      if (selectedNode == null)
      {
        MessageBox.Show(
          "Select a node first.",
          "Copy Node",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information);
        return;
      }

      bool includeRelationships =
        MessageBox.Show(
          "Copy node's relationships?",
          "Copy Node",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question) == DialogResult.Yes;

      INode newNode = _dependencyMapper.CreateNode();

      newNode.UpdateName($"{selectedNode.Name} Copy");
      newNode.UpdateDescription(selectedNode.Description);
      newNode.UpdateCategory(selectedNode.Category);

      if (includeRelationships)
      {
        foreach (var d in _dependencyMapper.GetDependencies(selectedNode))
        {
          _dependencyMapper.AddDependency(newNode, d);
        }

        foreach (var d in _dependencyMapper.GetDependants(selectedNode))
        {
          _dependencyMapper.AddDependency(d, newNode);
        }
      }

      var uiNode = new NodeWrapper(newNode);

      nodesList.Items.Add(uiNode);

      nodesList.SelectedItem = uiNode;

      nodeNameTxtBox.Focus();
    }

    private void exportCategoryDependencyDiagramsMenuItem_Click(object sender, EventArgs e)
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

      bool abort =
        MessageBox.Show(
          "This will export a dependency diagram for *each* node within the selected category, continue?",
          "Sure?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question) == DialogResult.No;

      if (abort)
      {
        return;
      }

      string selectedPath;

      using (var dlg = new FolderBrowserDialog())
      {
        dlg.ShowNewFolderButton = true;
        dlg.ShowDialog();

        selectedPath = dlg.SelectedPath;
      }

      if (string.IsNullOrEmpty(selectedPath))
      {
        return;
      }

      IEnumerable<INode> nodes =
      _dependencyMapper
        .Nodes
        .Where(n => n.Category.Equals(nodesListCategoryFilter.Text, StringComparison.OrdinalIgnoreCase));

      if (!nodes.Any())
      {
        MessageBox.Show(
          "No nodes found for selected category.",
          "Diagram Export",
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation);
        return;
      }

      IEnumerable<INode> keyNodes = CreateKeyDiagramNodes();

      CreateDiagram(
        keyNodes,
        graphVizBinPath,
        $@"{selectedPath}\Key");

      selectedPath = $@"{selectedPath}\{nodesListCategoryFilter.Text}";

      Directory.CreateDirectory(selectedPath);

      foreach (var n in nodes)
      {
        IList<INode> dependencies = _dependencyMapper.GetDependencies(n, true).ToList();

        dependencies.Add(n);

        CreateDiagram(
          dependencies,
          graphVizBinPath,
          $@"{selectedPath}\{n.Name}");
      }

      MessageBox.Show(
        "Export complete.",
        "Finished",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }

    private IEnumerable<INode> CreateKeyDiagramNodes()
    {
      var nodes = new List<INode>();
      var id = 1;

      foreach (var category in nodesListCategoryFilter.Items.Cast<string>())
      {
        if (category == NodesListCategoryFilterAll ||
          category == NodesListCategoryFilterCustom ||
          category == "Default")
        {
          continue;
        }

        nodes.Add(
          new Node(
            id++,
            category,
            string.Empty,
            category));
      }

      return nodes;
    }

    private void CreateDiagram(
      in IEnumerable<INode> nodes,
      in string graphVizBinPath,
      in string outputFilename)
    {
      var graphViz = new GraphVizDiagram(
        graphVizBinPath,
        @"GraphViz\DiagramTemplate.gv");

      nodes
        .ToList()
        .ForEach(n =>
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
          n.Description?.Length > 0 ? $"({n.Description})" : string.Empty,
          50,
          colour,
          shape);

        _dependencyMapper
          .GetDependencies(n)
          .ToList()
          .ForEach(d => graphViz.AddLinkToNode(n.Id, d.Id));
      });

      graphViz.CreateDiagram(outputFilename);
    }

    private void exportAllDiagramMenuItem_Click(object sender, EventArgs e)
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

      string selectedPath;

      using (var dlg = new FolderBrowserDialog())
      {
        dlg.ShowNewFolderButton = true;
        dlg.ShowDialog();

        selectedPath = dlg.SelectedPath;
      }

      if (string.IsNullOrEmpty(selectedPath))
      {
        return;
      }

      IEnumerable<INode> nodes = _dependencyMapper.Nodes;

      if (!nodes.Any())
      {
        MessageBox.Show(
          "No nodes found.",
          "Diagram Export",
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation);
        return;
      }

      IEnumerable<INode> keyNodes = CreateKeyDiagramNodes();

      CreateDiagram(
        keyNodes,
        graphVizBinPath,
        $@"{selectedPath}\Key");

      CreateDiagram(
        nodes,
        graphVizBinPath,
        $@"{selectedPath}\All");

      MessageBox.Show(
        "Export complete.",
        "Finished",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }
  }
}
