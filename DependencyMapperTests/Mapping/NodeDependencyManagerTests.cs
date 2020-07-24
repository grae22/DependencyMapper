using System;
using System.Collections.Generic;
using System.Linq;

using DependencyMapper.Mapping;

using NSubstitute;

using NUnit.Framework;

namespace DependencyMapperTests.Mapping
{
  [TestFixture]
  public class NodeDependencyManagerTests
  {
    [Test]
    public void GivenNodeAAndNodeB_WhenNodeAMadeDependentOnNodeB_ThenNodeBReturnedAsADependencyOfNodeA()
    {
      // Arrange.
      var testObject = new NodeDependencyManager();

      var nodeA = Substitute.For<INode>();
      var nodeB = Substitute.For<INode>();

      nodeA.Id.Returns(1);
      nodeB.Id.Returns(2);

      // Act.
      testObject.AddDependency(nodeA, nodeB);

      // Assert.
      bool result = testObject.IsDependant(nodeA, nodeB);

      Assert.IsTrue(result);
    }

    [Test]
    public void GivenNodeADependentOnNodeB_WhenDependencyRemoved_ThenNodeBIsNotReturnedAsADependencyOfNodeA()
    {
      // Arrange.
      var testObject = new NodeDependencyManager();

      var nodeA = Substitute.For<INode>();
      var nodeB = Substitute.For<INode>();

      nodeA.Id.Returns(1);
      nodeB.Id.Returns(2);

      testObject.AddDependency(nodeA, nodeB);

      // Act.
      testObject.RemoveDependency(nodeA, nodeB);

      // Assert.
      bool result = testObject.IsDependant(nodeA, nodeB);

      Assert.IsFalse(result);
    }

    [Test]
    public void GivenNodeWithDependencies_WhenDependenciesRetrieved_ThenCorrectNodesAreReturned()
    {
      // Arrange.
      var testObject = new NodeDependencyManager();

      var node0 = Substitute.For<INode>();
      var node1 = Substitute.For<INode>();
      var node1_1 = Substitute.For<INode>();
      var node1_2 = Substitute.For<INode>();

      node0.Id.Returns(1);
      node1.Id.Returns(2);
      node1_1.Id.Returns(3);
      node1_2.Id.Returns(4);

      testObject.AddDependency(node0, node1);
      testObject.AddDependency(node1, node1_1);
      testObject.AddDependency(node1, node1_2);

      // Act.
      IEnumerable<INode> dependencies = testObject.GetDependencies(node1);

      // Assert.
      Assert.That(dependencies.Contains(node1_1));
      Assert.That(dependencies.Contains(node1_2));

      Assert.That(!dependencies.Contains(node1));
      Assert.That(!dependencies.Contains(node0));
    }

    [Test]
    public void GivenNodeWithIndirectDependencies_WhenDependenciesRetrieved_ThenCorrectNodesAreReturned()
    {
      // Arrange.
      var testObject = new NodeDependencyManager();

      var node0 = Substitute.For<INode>();
      var node1 = Substitute.For<INode>();
      var node1_1 = Substitute.For<INode>();
      var node1_2 = Substitute.For<INode>();

      node0.Id.Returns(1);
      node1.Id.Returns(2);
      node1_1.Id.Returns(3);
      node1_2.Id.Returns(4);

      testObject.AddDependency(node0, node1);
      testObject.AddDependency(node1, node1_1);
      testObject.AddDependency(node1, node1_2);

      // Act.
      IEnumerable<INode> dependencies = testObject.GetDependencies(node0, true);

      // Assert.
      Assert.That(dependencies.Contains(node1));
      Assert.That(dependencies.Contains(node1_1));
      Assert.That(dependencies.Contains(node1_2));
      
      Assert.That(!dependencies.Contains(node0));
    }

    [Test]
    public void GivenNodeWithDependants_WhenDependantsRetrieved_ThenCorrectNodesAreReturned()
    {
      // Arrange.
      var testObject = new NodeDependencyManager();

      var node0 = Substitute.For<INode>();
      var node1 = Substitute.For<INode>();
      var node1_1 = Substitute.For<INode>();
      var node1_2 = Substitute.For<INode>();

      node0.Id.Returns(1);
      node1.Id.Returns(2);
      node1_1.Id.Returns(3);
      node1_2.Id.Returns(4);

      testObject.AddDependency(node0, node1_2);
      testObject.AddDependency(node1, node1_1);
      testObject.AddDependency(node1, node1_2);

      // Act.
      IEnumerable<INode> dependants = testObject.GetDependants(node1_2);

      // Assert.
      Assert.That(dependants.Contains(node1));
      Assert.That(dependants.Contains(node0));

      Assert.That(!dependants.Contains(node1_2));
      Assert.That(!dependants.Contains(node1_1));
    }

    [Test]
    public void GivenNodeWithIndirectDependants_WhenDependantsRetrieved_ThenCorrectNodesAreReturned()
    {
      // Arrange.
      var testObject = new NodeDependencyManager();

      var node0 = Substitute.For<INode>();
      var node1 = Substitute.For<INode>();
      var node1_1 = Substitute.For<INode>();
      var node1_2 = Substitute.For<INode>();

      node0.Id.Returns(1);
      node1.Id.Returns(2);
      node1_1.Id.Returns(3);
      node1_2.Id.Returns(4);

      testObject.AddDependency(node0, node1);
      testObject.AddDependency(node1, node1_1);
      testObject.AddDependency(node1, node1_2);

      // Act.
      IEnumerable<INode> dependants = testObject.GetDependants(node1_2, true);

      // Assert.
      Assert.That(dependants.Contains(node1));
      Assert.That(dependants.Contains(node0));

      Assert.That(!dependants.Contains(node1_2));
      Assert.That(!dependants.Contains(node1_1));
    }

    [Test]
    public void GivenNodeADependsOnNodeBWhichDependsOnNodeC_WhenNodeCIsMadeDependantOnNodeA_ThenExceptionRaised()
    {
      // Arrange.
      var testObject = new NodeDependencyManager();

      var nodeA = Substitute.For<INode>();
      var nodeB = Substitute.For<INode>();
      var nodeC = Substitute.For<INode>();

      nodeA.Id.Returns(1);
      nodeB.Id.Returns(2);
      nodeC.Id.Returns(3);

      testObject.AddDependency(nodeA, nodeB);
      testObject.AddDependency(nodeB, nodeC);

      // Act.
      // Assert.
      try
      {
        testObject.AddDependency(nodeC, nodeA);
      }
      catch (NodeMappingException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }
  }
}
