using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using DependencyMapper.GraphViz;
using DependencyMapper.Mapping;
using DependencyMapper.Ui;

namespace DependencyMapper
{
  public partial class MainForm : Form
  {
    private INodeDependencyMapper _dependencyMapper = NodeDependencyMapper.Instantiate();
    private string _saveFilename;

    public MainForm()
    {
      InitializeComponent();
    }

    private void newNodeBtn_Click(object sender, EventArgs e)
    {
      INode newNode = _dependencyMapper.CreateNode();

      newNode.UpdateName("New Node");

      var uiNode = new NodeWrapper(newNode);

      nodesList.Items.Add(uiNode);

      nodesList.SelectedItem = uiNode;
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

      Save();
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
      
      nodesList.Items.Clear();

      _dependencyMapper
        .Nodes
        .ToList()
        .ForEach(n =>
        {
          var wrappedNode = new NodeWrapper(n);

          nodesList.Items.Add(wrappedNode);
        });

      UpdateDiagram();
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
      var graphViz = new GraphVizDiagram(
        @"F:\Apps\GraphViz\bin\",
        @"GraphViz\DiagramTemplate.gv");

      _dependencyMapper
        .Nodes
        .ToList()
        .ForEach(n =>
        {
          graphViz.AddNode(
            n.Id,
            n.Name,
            n.Description,
            50,
            Color.Blue,
            GraphVizDiagram.Node.NodeShape.BOX);

          _dependencyMapper
            .GetDependencies(n)
            .ToList()
            .ForEach(d => graphViz.AddLinkToNode(n.Id, d.Id));
        });

      graphViz.CreateDiagram("diagram");

      using (Image img = new Bitmap(
        $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\GraphVisTmp\diagram.bmp"))
      {
        diagramPicBox.Image = img;
        diagramPicBox.Refresh();
      }
    }
  }
}
