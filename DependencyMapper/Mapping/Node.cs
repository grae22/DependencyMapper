using System;

namespace DependencyMapper.Mapping
{
  internal class Node : INode
  {
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }

    public Node(
      in int id,
      in string name,
      in string description,
      in string category)
    {
      if (id < 1)
      {
        throw new ArgumentException($"{nameof(id)} cannot be zero or negative.");
      }

      Id = id;
      Name = name;
      Description = description;
      Category = category;
    }

    public void UpdateName(in string name)
    {
      Name = name;
    }

    public void UpdateDescription(in string description)
    {
      Description = description;
    }

    public void UpdateCategory(in string category)
    {
      Category = category;
    }
  }
}
