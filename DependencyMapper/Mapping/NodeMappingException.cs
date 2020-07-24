using System;

namespace DependencyMapper.Mapping
{
  public class NodeMappingException : Exception
  {
    public NodeMappingException(in string message)
    :
      base(message)
    {
    }
  }
}
