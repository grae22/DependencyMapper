using System.Collections.Generic;

namespace DependencyMapper.Mapping
{
  public interface INodeDependencyMapper
  {
    IEnumerable<INode> Nodes { get; }

    INode CreateNode();

    void RemoveNode(in int nodeId);

    bool IsDependant(
      in INode dependant,
      in INode dependency);

    IEnumerable<INode> GetDependencies(
      in INode dependant,
      in bool includeIndirectDependencies = false);

    IEnumerable<INode> GetDependants(
      in INode dependency,
      in bool includeIndirectDependants = false);

    void AddDependency(
      in INode dependant,
      in INode dependency);

    void RemoveDependency(
      in INode dependant,
      in INode dependency);

    string Serialise();
  }
}
