namespace DependencyMapper.Mapping
{
  internal class NodeFactory
  {
    private int _nextNodeId = 1;

    public INode CreateNode()
    {
      var nodeId = AllocateNodeId();
      var nodeName = "";
      var nodeDescription = "";
      var nodeCategory = "Default";

      return new Node(
        nodeId,
        nodeName,
        nodeDescription,
        nodeCategory);
    }

    private int AllocateNodeId()
    {
      return _nextNodeId++;
    }
  }
}
