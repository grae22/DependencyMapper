using System;

using DependencyMapper.Mapping;

namespace DependencyMapper.Ui
{
  internal class NodeWrapper
  {
    public INode Node { get; }

    public NodeWrapper(in INode node)
    {
      Node = node ?? throw new ArgumentNullException(nameof(node));
    }

    public override string ToString()
    {
      return Node.Name;
    }
  }
}
