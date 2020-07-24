using System;
using System.Collections.Generic;

using DependencyMapper.Mapping.Persistance;

using Newtonsoft.Json;

namespace DependencyMapper.Mapping
{
  internal class NodeDependencyMapper : INodeDependencyMapper
  {
    public static NodeDependencyMapper Instantiate()
    {
      return new NodeDependencyMapper(
        new NodeFactory(),
        new NodeDependencyManager());
    }

    private readonly INodeFactory _nodeFactory;
    private readonly INodeDependencyManager _nodeDependencyManager;
    private readonly IList<INode> _nodes = new List<INode>();

    private NodeDependencyMapper(
      in INodeFactory nodeFactory,
      in INodeDependencyManager nodeDependencyManager)
    {
      _nodeFactory = nodeFactory ?? throw new ArgumentNullException(nameof(nodeFactory));
      _nodeDependencyManager = nodeDependencyManager ?? throw new ArgumentNullException(nameof(nodeDependencyManager));
    }

    public INode CreateNode()
    {
      INode node = _nodeFactory.CreateNode();

      _nodes.Add(node);

      return node;
    }

    public void RemoveNode(in int nodeId)
    {
      // TODO
    }

    public string Serialise()
    {
      var model = new PersistanceModel
      {
        Nodes = new List<INode>(_nodes)
      };

      return JsonConvert.SerializeObject(model);
    }
  }
}
