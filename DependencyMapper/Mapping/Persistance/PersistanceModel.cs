using System.Collections.Generic;

namespace DependencyMapper.Mapping.Persistance
{
  internal class PersistanceModel
  {
    public IList<INode> Nodes { get; set; }
    public IDictionary<int, List<int>> DependenciesByDependantNodeId { get; set; }
  }
}
