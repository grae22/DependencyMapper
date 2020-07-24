using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyMapper.Mapping
{
  internal class NodeDependencyManager : INodeDependencyManager
  {
    private const int MaxRecursiveNodeSearchLevel = 1024;

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

      bool wouldCauseACyclicDependency = IsDependant(
        dependency,
        dependant,
        true);

      if (wouldCauseACyclicDependency)
      {
        throw new NodeMappingException("Mapping would cause a cyclic dependency.");
      }

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

    public bool IsDependant(
      in INode dependant,
      in INode dependency,
      in bool includeIndirectDependencies = false)
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

      bool hasDirectDependency = _dependenciesByDependantNodeId[dependant.Id].Contains(dependency.Id);

      if (hasDirectDependency)
      {
        return true;
      }

      if (!includeIndirectDependencies)
      {
        return false;
      }

      IEnumerable<INode> dependencies = GetDependencies(dependant, true);

      int dependencyId = dependency.Id;

      return dependencies.Any(d => d.Id == dependencyId);
    }

    public IEnumerable<INode> GetDependencies(
      in INode dependant,
      in bool includeIndirectDependencies = false)
    {
      if (dependant == null)
      {
        throw new ArgumentNullException(nameof(dependant));
      }

      if (!_dependenciesByDependantNodeId.ContainsKey(dependant.Id))
      {
        return new INode[0];
      }

      var dependencies = new List<INode>(
        _dependenciesByDependantNodeId[dependant.Id]
          .Join(
            _nodesById.Values,
            nodeId => nodeId,
            node => node.Id,
            (nodeId, node) => node));

      if (!includeIndirectDependencies)
      {
        return dependencies;
      }

      var dependenciesCopy = new List<INode>(dependencies);
      var recursionLevel = 0;

      foreach (var node in dependenciesCopy)
      {
        GetDependenciesRecursive(
          node,
          dependencies,
          recursionLevel);
      }

      return dependencies;
    }

    public IEnumerable<INode> GetDependants(
      in INode dependency,
      in bool includeIndirectDependants = false)
    {
      if (dependency == null)
      {
        throw new ArgumentNullException(nameof(dependency));
      }

      if (!_dependantsByDependencyNodeId.ContainsKey(dependency.Id))
      {
        return new INode[0];
      }

      var dependants = new List<INode>(_dependantsByDependencyNodeId[dependency.Id]
        .Join(
          _nodesById.Values,
          nodeId => nodeId,
          node => node.Id,
          (nodeId, node) => node));

      if (!includeIndirectDependants)
      {
        return dependants;
      }

      var dependantsCopy = new List<INode>(dependants);
      var recursionLevel = 0;

      foreach (var node in dependantsCopy)
      {
        GetDependantsRecursive(
          node,
          dependants,
          recursionLevel);
      }

      return dependants;
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

    private void GetDependenciesRecursive(
      in INode dependant,
      in List<INode> dependencies,
      in int recursionLevel)
    {
      if (recursionLevel + 1 > MaxRecursiveNodeSearchLevel)
      {
        // TODO: This is currently a silent failure, could be improved.
        return;
      }

      IEnumerable<int> currentDependencyIDs = _dependenciesByDependantNodeId[dependant.Id];

      foreach (var id in currentDependencyIDs)
      {
        INode dependency = _nodesById[id];

        dependencies.Add(dependency);

        GetDependenciesRecursive(
          dependency,
          dependencies,
          recursionLevel + 1);
      }
    }

    private void GetDependantsRecursive(
      in INode dependency,
      in List<INode> dependants,
      in int recursionLevel)
    {
      if (recursionLevel + 1 > MaxRecursiveNodeSearchLevel)
      {
        // TODO: This is currently a silent failure, could be improved.
        return;
      }

      IEnumerable<int> currentDependantIDs = _dependantsByDependencyNodeId[dependency.Id];

      foreach (var id in currentDependantIDs)
      {
        INode dependant = _nodesById[id];

        dependants.Add(dependant);

        GetDependantsRecursive(
          dependant,
          dependants,
          recursionLevel + 1);
      }
    }
  }
}
