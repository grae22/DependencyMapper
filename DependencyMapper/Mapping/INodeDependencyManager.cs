using System.Collections;
using System.Collections.Generic;

namespace DependencyMapper.Mapping
{
  public interface INodeDependencyManager
  {
    void AddDependency(
      in INode dependant,
      in INode dependency);

    void RemoveDependency(
      in INode dependant,
      in INode dependency);

    bool IsDependant(
      in INode dependant,
      in INode dependency,
      in bool includeIndirectDependencies = false);

    IEnumerable<INode> GetDependencies(
      in INode dependant,
      in bool includeIndirectDependencies = false);

    IEnumerable<INode> GetDependants(
      in INode dependency,
      in bool includeIndirectDependencies = false);
  }
}
