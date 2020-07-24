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

    bool IsDependent(
      in INode dependant,
      in INode dependency);

    IEnumerable<INode> GetDependencies(in INode dependant);

    IEnumerable<INode> GetDependants(in INode dependency);
  }
}
