using System.Collections.Generic;

namespace DependencyMapper.Mapping
{
  public interface INodeDependencyMapper
  {
    IEnumerable<INode> Nodes { get; }

    INode CreateNode();

    void RemoveNode(in int nodeId);

    string Serialise();
  }
}
