namespace DependencyMapper.Mapping
{
  public interface INodeDependencyMapper
  {
    INode CreateNode();

    void RemoveNode(in int nodeId);

    string Serialise();
  }
}
