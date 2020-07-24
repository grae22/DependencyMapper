using NUnit.Framework;

using DependencyMapper.Mapping;

namespace DependencyMapperTests.Mapping
{
  [TestFixture]
  public class NodeFactoryTests
  {
    [Test]
    public void GivenNoNodesExist_WhenFactoryCreatesNode_ThenReturnedNodeIsNotNull()
    {
      // Arrange.
      var testObject = new NodeFactory();

      // Act.
      INode node = testObject.CreateNode();

      // Assert.
      Assert.IsNotNull(node);
    }

    [Test]
    public void GivenOneNodeExists_WhenNextNodeCreated_ThenNewNodeHasDifferentId()
    {
      // Arrange.
      var testObject = new NodeFactory();

      INode firstNode = testObject.CreateNode();

      // Act.
      INode secondNode = testObject.CreateNode();

      // Assert.
      Assert.AreNotEqual(firstNode.Id, secondNode.Id);
    }

    [Test]
    public void GivenNoPreCondition_WhenNodeCreated_ThenCategoryHasDefaultValue()
    {
      // Arrange.
      var testObject = new NodeFactory();

      // Act.
      INode node = testObject.CreateNode();

      // Assert.
      Assert.AreEqual("Default", node.Category);
    }

    [Test]
    public void GivenSeededNextNodeIdFactory_WhenNodeCreated_ThenNewNodeHasSeededNodeId()
    {
      // Arrange.
      const int nodeIdSeed = 123;

      var testObject = new NodeFactory(nodeIdSeed);

      // Act.
      INode node = testObject.CreateNode();

      // Assert.
      Assert.AreEqual(nodeIdSeed, node.Id);
    }
  }
}
