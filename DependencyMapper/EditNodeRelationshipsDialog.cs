using System;
using System.Collections.Generic;
using System.Linq;
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

    private void RemoveNodesDependentOnSpecifiedNode(
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
      }
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

      PopulateNodesList();
    }

    private void PopulateNodesList()
    {
      nodesList.Items.Clear();

      var nodes = new List<INode>(_nodeDependencyMapper.Nodes);

      nodes.Remove(_node);

      if (_mode == RelationshipMode.Dependencies)
      {
        RemoveNodesDependingOnSpecifiedNode(_node, nodes);
      }
      else
      {
        RemoveNodesDependentOnSpecifiedNode(_node, nodes);
      }

      foreach (var n in nodes)
      {
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

        var wrappedNode = new NodeWrapper(n);

        nodesList.Items.Add(wrappedNode, isBoxChecked);
      }
    }

    private void clearFilterBtn_Click(object sender, EventArgs e)
    {
      filterTxtBox.Text = string.Empty;

      PopulateNodesList();

      filterTxtBox.Focus();
    }
  }
}
