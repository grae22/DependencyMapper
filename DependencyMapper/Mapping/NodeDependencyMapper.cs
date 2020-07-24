using System;
using System.Collections.Generic;
using System.Linq;

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

    public static NodeDependencyMapper InstantiateFromSerialisedData(in string data)
    {
      var model = JsonConvert.DeserializeObject<PersistanceModel>(
        data,
        new JsonSerializerSettings()
        {
          TypeNameHandling = TypeNameHandling.Auto
        });

      int largestNodeId = model.Nodes.Max(n => n.Id);

      var nodeFactory = new NodeFactory(largestNodeId + 1);
      var nodeDependencyManager = new NodeDependencyManager();

      return new NodeDependencyMapper(
        nodeFactory,
        nodeDependencyManager,
        model.Nodes);
    }

    public IEnumerable<INode> Nodes => _nodes;

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

    private NodeDependencyMapper(
      in INodeFactory nodeFactory,
      in INodeDependencyManager nodeDependencyManager,
      in IList<INode> nodes)
    {
      _nodeFactory = nodeFactory ?? throw new ArgumentNullException(nameof(nodeFactory));
      _nodeDependencyManager = nodeDependencyManager ?? throw new ArgumentNullException(nameof(nodeDependencyManager));

      if (nodes == null)
      {
        throw new ArgumentNullException(nameof(nodes));
      }

      _nodes = new List<INode>(nodes);
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

    public bool IsDependant(
      in INode dependant,
      in INode dependency)
    {
      return _nodeDependencyManager.IsDependant(
        dependant,
        dependency,
        true);
    }

    public string Serialise()
    {
      var model = new PersistanceModel
      {
        Nodes = new List<INode>(_nodes)
      };

      return JsonConvert.SerializeObject(
        model,
        new JsonSerializerSettings()
        {
          TypeNameHandling = TypeNameHandling.Auto
        });
    }
  }
}
