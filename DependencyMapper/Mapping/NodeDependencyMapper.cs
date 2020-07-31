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
        model.Nodes,
        model.DependenciesByDependantNodeId);
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
      in IList<INode> nodes,
      in IDictionary<int, List<int>> dependencyIDsByDependantNodeId)
    {
      _nodeFactory = nodeFactory ?? throw new ArgumentNullException(nameof(nodeFactory));
      _nodeDependencyManager = nodeDependencyManager ?? throw new ArgumentNullException(nameof(nodeDependencyManager));

      if (nodes == null)
      {
        throw new ArgumentNullException(nameof(nodes));
      }

      if (dependencyIDsByDependantNodeId == null)
      {
        throw new ArgumentNullException(nameof(dependencyIDsByDependantNodeId));
      }

      _nodes = new List<INode>(nodes);

      foreach (var d in dependencyIDsByDependantNodeId)
      {
        int dependantId = d.Key;
        INode dependantNode = _nodes.First(n => n.Id == dependantId);

        IEnumerable<int> dependencyIDs = d.Value;

        foreach (var id in dependencyIDs)
        {
          INode dependency = _nodes.First(n => n.Id == id);

          AddDependency(dependantNode, dependency);
        }
      }
    }

    public INode CreateNode()
    {
      INode node = _nodeFactory.CreateNode();

      _nodes.Add(node);

      return node;
    }

    public void RemoveNode(in int nodeId)
    {
      int nodeIdLocal = nodeId;

      if (!_nodes.Any(n => n.Id == nodeIdLocal))
      {
        return;
      }

      INode node = _nodes.Single<INode>(n => n.Id == nodeIdLocal);

      GetDependencies(node)
        .ToList()
        .ForEach(d => RemoveDependency(node, d));

      GetDependants(node)
        .ToList()
        .ForEach(d => RemoveDependency(d, node));

      _nodes.Remove(node);
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

    public IEnumerable<INode> GetDependencies(
      in INode dependant,
      in bool includeIndirectDependencies = false)
    {
      return _nodeDependencyManager.GetDependencies(dependant, includeIndirectDependencies);
    }

    public IEnumerable<INode> GetDependants(
      in INode dependency,
      in bool includeIndirectDependants = false)
    {
      return _nodeDependencyManager.GetDependants(dependency, includeIndirectDependants);
    }

    public void AddDependency(
      in INode dependant,
      in INode dependency)
    {
      _nodeDependencyManager.AddDependency(dependant, dependency);
    }

    public void RemoveDependency(
      in INode dependant,
      in INode dependency)
    {
      _nodeDependencyManager.RemoveDependency(dependant, dependency);
    }

    public string Serialise()
    {
      var model = new PersistanceModel
      {
        Nodes = new List<INode>(_nodes),
        DependenciesByDependantNodeId = new Dictionary<int, List<int>>()
      };

      PopulateDependencyIDsByDependantNodeId(model.DependenciesByDependantNodeId);

      return JsonConvert.SerializeObject(
        model,
        new JsonSerializerSettings()
        {
          Formatting = Formatting.Indented,
          TypeNameHandling = TypeNameHandling.Auto
        });
    }

    private void PopulateDependencyIDsByDependantNodeId(
      in IDictionary<int, List<int>> dependencyIDsByDependantNodeId)
    {
      foreach (var node in _nodes)
      {
        IEnumerable<INode> dependencies = _nodeDependencyManager.GetDependencies(node);

        if (!dependencies.Any())
        {
          continue;
        }

        var dependencyIDs = new List<int>(dependencies.Select(d => d.Id));

        dependencyIDsByDependantNodeId.Add(node.Id, dependencyIDs);
      }
    }
  }
}
