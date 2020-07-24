using System;
using System.Collections.Generic;
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
      var nodes = new List<INode>(_nodeDependencyMapper.Nodes);

      nodes.Remove(_node);

      if (_mode == RelationshipMode.Dependencies)
      {
        RemoveNodesDependingOnSpecifiedNode(_node, nodes);
      }

      nodes
        .ForEach(n =>
        {
          var wrappedNode = new NodeWrapper(n);

          nodesList.Items.Add(wrappedNode);
        });
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

    private void nodesList_SelectedValueChanged(object sender, EventArgs e)
    {
      //nodesList.chec
    }
  }
}
