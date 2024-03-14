using System;

namespace DependencyMapper.Mapping
{
  internal class NodeFactory : INodeFactory
  {
    private const int FirstNodeId = 1;

    private int _nextNodeId = 1;

    public NodeFactory(in int nextNodeId = FirstNodeId)
    {
      if (nextNodeId < FirstNodeId)
      {
        throw new ArgumentException($"{nextNodeId} cannot be smaller than {FirstNodeId}.");
      }

      _nextNodeId = nextNodeId;
    }

    public INode CreateNode()
    {
      var nodeId = AllocateNodeId();
      var nodeName = "";
      var nodeDescription = "";
      var nodeCategory = "Default";
      var isComplete = false;

      return new Node(
        nodeId,
        nodeName,
        nodeDescription,
        nodeCategory,
        isComplete);
    }

    private int AllocateNodeId()
    {
      return _nextNodeId++;
    }
  }
}
