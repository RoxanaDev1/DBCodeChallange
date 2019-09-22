
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solution.Tests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void NodeTests_CreateEmptyNode()
        {
            Node testNode = new Node();
            Assert.AreEqual(0, testNode.weight);
            Assert.IsNotNull(testNode.id);
            Assert.IsNotNull(testNode.neighbors);
            Assert.AreEqual(0, testNode.neighbors.Count);
        }

        [TestMethod]
        public void NodeTests_CreateNodeWithWeight()
        {
            int weight = 20;
            Node testNode = new Node(weight);
            Assert.AreEqual(weight, testNode.weight);
            Assert.IsNotNull(testNode.id);
            Assert.IsNotNull(testNode.neighbors);
            Assert.AreEqual(0, testNode.neighbors.Count);
        }

        [TestMethod]
        public void NodeTests_AddOddNeighborToEvenNode()
        {
            Node evenNode = new Node(20);
            Node oddNode = new Node(31);
            bool isAdded = evenNode.AddNeighbor(oddNode);
            Assert.IsTrue(isAdded);
        }

        [TestMethod]
        public void NodeTests_AddOddNeighborToOddNode()
        {
            Node oddNode = new Node(21);
            Node anotherOddNode = new Node(31);
            bool isAdded = oddNode.AddNeighbor(oddNode);
            Assert.IsFalse(isAdded);
        }

        [TestMethod]
        public void NodeTests_AddEvenNeighborToOddNode()
        {
            Node evenNode = new Node(20);
            Node oddNode = new Node(31);
            bool isAdded = oddNode.AddNeighbor(evenNode);
            Assert.IsTrue(isAdded);
        }

        [TestMethod]
        public void NodeTests_AddEvenNeighborToEvenNode()
        {
            Node evenNode = new Node(20);
            Node anotherEvenNode = new Node(30);
            bool isAdded = evenNode.AddNeighbor(anotherEvenNode);
            Assert.IsFalse(isAdded);
        }
    }
}