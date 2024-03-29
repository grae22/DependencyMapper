﻿namespace DependencyMapper.Mapping
{
  public interface INode
  {
    int Id { get; }
    string Name { get; }
    string Description { get; }
    string Category { get; }
    bool IsCompleted { get; }

    void UpdateName(in string name);
    void UpdateDescription(in string description);
    void UpdateCategory(in string category);
    void MarkComplete();
    void MarkIncomplete();
  }
}
