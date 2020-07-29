using System;
using System.Linq;

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
      if (Node.Category.Length > 0)
      {
        string abbreviatedCategory = new string(
          Node
            .Category
            .Where(c => c >= 'A' && c <= 'Z')
            .ToArray());

        return $"{Node.Name} [{abbreviatedCategory}]";
      }
      
      return $"{Node.Name} [?]";
    }
  }
}
