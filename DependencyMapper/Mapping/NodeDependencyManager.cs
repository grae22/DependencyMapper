using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyMapper.Mapping
{
  internal class NodeDependencyManager : INodeDependencyManager
  {
    private Dictionary<int, INode> _nodesById = new Dictionary<int, INode>();
    private Dictionary<int, IList<int>> _dependenciesByDependantNodeId = new Dictionary<int, IList<int>>();
    private Dictionary<int, IList<int>> _dependantsByDependencyNodeId = new Dictionary<int, IList<int>>();

    public void AddDependency(
      in INode dependant,
      in INode dependency)
    {
      if (dependant == null)
      {
        throw new ArgumentNullException(nameof(dependant));
      }

      if (dependency == null)
      {
        throw new ArgumentNullException(nameof(dependency));
      }

      AddNode(dependant);
      AddNode(dependency);

      if (!_dependenciesByDependantNodeId[dependant.Id].Contains(dependency.Id))
      {
        _dependenciesByDependantNodeId[dependant.Id].Add(dependency.Id);
      }

      if (!_dependantsByDependencyNodeId[dependency.Id].Contains(dependant.Id))
      {
        _dependantsByDependencyNodeId[dependency.Id].Add(dependant.Id);
      }
    }

    public void RemoveDependency(
      in INode dependant,
      in INode dependency)
    {
      if (dependant == null)
      {
        throw new ArgumentNullException(nameof(dependant));
      }

      if (dependency == null)
      {
        throw new ArgumentNullException(nameof(dependency));
      }

      AddNode(dependant);
      AddNode(dependency);

      if (_dependenciesByDependantNodeId[dependant.Id].Contains(dependency.Id))
      {
        _dependenciesByDependantNodeId[dependant.Id].Remove(dependency.Id);
      }

      if (_dependantsByDependencyNodeId[dependency.Id].Contains(dependant.Id))
      {
        _dependantsByDependencyNodeId[dependency.Id].Remove(dependant.Id);
      }      
    }

    public bool IsDependent(
      in INode dependant,
      in INode dependency)
    {
      if (dependant == null)
      {
        throw new ArgumentNullException(nameof(dependant));
      }

      if (dependency == null)
      {
        throw new ArgumentNullException(nameof(dependency));
      }

      if (!_dependenciesByDependantNodeId.ContainsKey(dependant.Id))
      {
        return false;
      }

      return _dependenciesByDependantNodeId[dependant.Id].Contains(dependency.Id);
    }

    public IEnumerable<INode> GetDependencies(in INode dependant)
    {
      if (dependant == null)
      {
        throw new ArgumentNullException(nameof(dependant));
      }

      if (!_dependenciesByDependantNodeId.ContainsKey(dependant.Id))
      {
        return new INode[0];
      }

      return _dependenciesByDependantNodeId[dependant.Id]
        .Join(
          _nodesById.Values,
          nodeId => nodeId,
          node => node.Id,
          (nodeId, node) => node);
    }

    public IEnumerable<INode> GetDependants(in INode dependency)
    {
      if (dependency == null)
      {
        throw new ArgumentNullException(nameof(dependency));
      }

      if (!_dependantsByDependencyNodeId.ContainsKey(dependency.Id))
      {
        return new INode[0];
      }

      return _dependantsByDependencyNodeId[dependency.Id]
        .Join(
          _nodesById.Values,
          nodeId => nodeId,
          node => node.Id,
          (nodeId, node) => node);
    }

    private void AddNode(in INode node)
    {
      if (_nodesById.ContainsKey(node.Id))
      {
        return;
      }

      _nodesById.Add(node.Id, node);
      _dependenciesByDependantNodeId.Add(node.Id, new List<int>());
      _dependantsByDependencyNodeId.Add(node.Id, new List<int>());
    }
  }
}
