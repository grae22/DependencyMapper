using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DependencyMapper.Mapping;
using DependencyMapper.Ui;

namespace DependencyMapper
{
  public partial class EditNodeRelationshipsDialog : Form
  {
    public enum RelationshipMode
    {
      Dependencies,
      Dependants
    }

    private readonly INode _node;
    private readonly INodeDependencyMapper _nodeDependencyMapper;
    private readonly RelationshipMode _mode;
    private readonly List<INode> _nodesAdded = new List<INode>();
    private readonly List<INode> _nodesRemoved = new List<INode>();

    public EditNodeRelationshipsDialog(
      in INode node,
      in INodeDependencyMapper nodeDependencyMapper,
      in RelationshipMode mode)
    {
      _node = node;
      _nodeDependencyMapper = nodeDependencyMapper;
      _mode = mode;

      InitializeComponent();

      Text = _mode == RelationshipMode.Dependencies ?
        "Select node's dependencies..." : "Select node's dependants";
    }

    private void EditNodeRelationshipsDialog_Load(object sender, EventArgs e)
    {
      PopulateNodesList();
    }

    private void RemoveNodesDependingOnSpecifiedNode(
      in INode node,
      in IList<INode> nodes)
    {
      var nodesToRemove = new List<INode>();

      foreach (var n in nodes)
      {
        bool isDependant = _nodeDependencyMapper.IsDependant(n, node);

        if (isDependant)
        {
          nodesToRemove.Add(n);
        }
      }

      foreach (var n in nodesToRemove)
      {
        nodes.Remove(n);
      }
    }

    private void RemoveNodesIndirectlyDependingOnSpecifiedNode(
      in INode node,
      in IList<INode> nodes)
    {
      IEnumerable<INode> directDependants = _nodeDependencyMapper.GetDependants(node);

      var nodesToRemove = new List<INode>();

      foreach (var n in nodes)
      {
        bool isDependant = _nodeDependencyMapper.IsDependant(n, node);
        bool isDirectDependant = directDependants.Contains(n);

        if (isDependant && !isDirectDependant)
        {
          nodesToRemove.Add(n);
        }
      }

      foreach (var n in nodesToRemove)
      {
        nodes.Remove(n);
      }
    }

    private void RemoveNodesSpecifiedNodeDependsOn(
      in INode node,
      in IList<INode> nodes)
    {
      var nodesToRemove = new List<INode>();

      foreach (var n in nodes)
      {
        bool isDependant = _nodeDependencyMapper.IsDependant(node, n);

        if (isDependant)
        {
          nodesToRemove.Add(n);
        }
      }

      foreach (var n in nodesToRemove)
      {
        nodes.Remove(n);
      }
    }

    private void RemoveNodesSpecifiedNodeIndirectlyDependsOn(
      in INode node,
      in IList<INode> nodes)
    {
      IEnumerable<INode> directDependencies = _nodeDependencyMapper.GetDependencies(node);

      var nodesToRemove = new List<INode>();

      foreach (var n in nodes)
      {
        bool isDependant = _nodeDependencyMapper.IsDependant(node, n);
        bool isDirectDependant = directDependencies.Contains(n);

        if (isDependant && !isDirectDependant)
        {
          nodesToRemove.Add(n);
        }
      }

      foreach (var n in nodesToRemove)
      {
        nodes.Remove(n);
      }
    }

    private void nodesList_SelectedValueChanged(object sender, EventArgs e)
    {
      if (nodesList.SelectedItem == null)
      {
        return;
      }

      INode node = ((NodeWrapper)nodesList.SelectedItem).Node;

      bool isBoxChecked = nodesList.CheckedItems.Contains(nodesList.SelectedItem);

      if (isBoxChecked)
      {
        if (_mode == RelationshipMode.Dependencies)
        {
          _nodeDependencyMapper.AddDependency(_node, node);
        }
        else
        {
          _nodeDependencyMapper.AddDependency(node, _node);
        }

        if (!_nodesRemoved.Contains(node))
        {
          _nodesAdded.Add(node);
        }

        _nodesRemoved.Remove(node);
      }
      else
      {
        if (_mode == RelationshipMode.Dependencies)
        {
          _nodeDependencyMapper.RemoveDependency(_node, node);
        }
        else
        {
          _nodeDependencyMapper.RemoveDependency(node, _node);
        }

        if (!_nodesAdded.Contains(node))
        {
          _nodesRemoved.Add(node);
        }

        _nodesAdded.Remove(node);
      }

      UpdateChanges();
      PopulateNodesList();
    }

    private void closeBtn_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void filterTxtBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != 13)
      {
        return;
      }

      nodesList.Items.Clear();

      PopulateNodesList();
    }

    private void PopulateNodesList()
    {
      var nodes = new List<INode>(_nodeDependencyMapper.Nodes);

      nodes.Remove(_node);

      if (_mode == RelationshipMode.Dependencies)
      {
        //RemoveNodesDependingOnSpecifiedNode(_node, nodes);

        if (!showIndirectRelationsChkBox.Checked)
        {
          RemoveNodesSpecifiedNodeIndirectlyDependsOn(_node, nodes);
        }
      }
      else
      {
        //RemoveNodesSpecifiedNodeDependsOn(_node, nodes);

        if (!showIndirectRelationsChkBox.Checked)
        {
          RemoveNodesIndirectlyDependingOnSpecifiedNode(_node, nodes);
        }
      }

      foreach (var n in nodes)
      {
        if (n == _node)
        {
          continue;
        }

        if (filterTxtBox.Text.Any() &&
          !n.Name.Contains(
            filterTxtBox.Text,
            StringComparison.OrdinalIgnoreCase))
        {
          continue;
        }

        bool isBoxChecked;

        if (_mode == RelationshipMode.Dependencies)
        {
          isBoxChecked = _nodeDependencyMapper.IsDependant(_node, n);
        }
        else
        {
          isBoxChecked = _nodeDependencyMapper.IsDependant(n, _node);
        }

        bool alreadyExists =
          nodesList
            .Items
            .Cast<NodeWrapper>()
            .ToList()
            .Any(i => i.Node.Id == n.Id);

        if (!alreadyExists)
        {
          var wrappedNode = new NodeWrapper(n);

          nodesList.Items.Add(wrappedNode, isBoxChecked);
        }
      }

      nodesList
        .Items
        .Cast<NodeWrapper>()
        .ToList()
        .Where(i => !nodes.Any(n => n.Id == i.Node.Id))
        .ToList()
        .ForEach(n => nodesList.Items.Remove(n));
    }

    private void clearFilterBtn_Click(object sender, EventArgs e)
    {
      filterTxtBox.Text = string.Empty;

      PopulateNodesList();

      filterTxtBox.Focus();
    }

    private void UpdateChanges()
    {
      var changes = new StringBuilder();

      _nodesAdded.ForEach(n => changes.Append($"+{n.Name}{Environment.NewLine}"));
      _nodesRemoved.ForEach(n => changes.Append($"-{n.Name}{Environment.NewLine}"));

      changesLbl.Text = changes.ToString();
    }

    private void showIndirectRelationsChkBox_CheckedChanged(object sender, EventArgs e)
    {
      PopulateNodesList();
    }
  }
}
