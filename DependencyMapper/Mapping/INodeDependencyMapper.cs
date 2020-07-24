using System.Collections.Generic;

namespace DependencyMapper.Mapping
{
  public interface INodeDependencyMapper
  {
    IEnumerable<INode> Nodes { get; }

    INode CreateNode();

    void RemoveNode(in int nodeId);

    public bool IsDependant(
      in INode dependant,
      in INode dependency);

    string Serialise();
  }
}
