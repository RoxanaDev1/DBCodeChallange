
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solution.Tests
{
    [TestClass]
    public class DirectedGraphTests
    {

        [TestMethod]
        public void DirectedGraphTests_CreateEmptyGraph()
        {
            DirectedGraph myGraph = new DirectedGraph();
            Assert.AreEqual(0, myGraph.maxLength);
            Assert.AreEqual(0, myGraph.nodes.Count);
        }

        [TestMethod]
        public void DirectedGraphTests_BuildGraphFromValidInputMatrix()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)},
                new Node[]{new Node(5), new Node(7)},
                new Node[]{new Node(10), new Node(20), new Node(30)}};
            DirectedGraph myGraph = new DirectedGraph();
            myGraph.BuildGraph(inputMatrix);
            Assert.AreEqual(3, myGraph.maxLength);
            Assert.AreEqual(6, myGraph.nodes.Count);
        }

        [TestMethod]
        public void DirectedGraphTests_BuildGraphFromInValidInputMatrix()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)},
                new Node[]{new Node(5), new Node(7), new Node(8)},
                new Node[]{new Node(10), new Node(20), new Node(30)}};
            DirectedGraph myGraph = new DirectedGraph();
            try
            {
                myGraph.BuildGraph(inputMatrix);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }

        [TestMethod]
        public void DirectedGraphTests_getRootNodeWhereNodeExists()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)}};
            DirectedGraph myGraph = new DirectedGraph();
            myGraph.BuildGraph(inputMatrix);
            Assert.IsNotNull(myGraph.getRootNode());
        }

        [TestMethod]
        public void DirectedGraphTests_getRootNodeWhereNodeNotExists()
        {
            List<Node[]> inputMatrix = new List<Node[]>();
            DirectedGraph myGraph = new DirectedGraph();
            myGraph.BuildGraph(inputMatrix);
            Assert.IsNull(myGraph.getRootNode());
        }

        [TestMethod]
        public void DirectedGraphTests_SearchMaxPathsWhereSuchPathIsFound()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)},
                new Node[]{new Node(5), new Node(7)},
                new Node[]{new Node(10), new Node(20), new Node(30)}};
            DirectedGraph myGraph = new DirectedGraph();
            myGraph.BuildGraph(inputMatrix);
            myGraph.PrintGraph();
            List<List<Node>> foundPaths = new List<List<Node>>();
            myGraph.SearchMaxPaths(myGraph.nodes[0], new List<Node>(), foundPaths);
            Assert.AreEqual(4, foundPaths.Count);
        }

        [TestMethod]
        public void DirectedGraphTests_SearchMaxPathsWhereSuchPathIsNotFound()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)},
                new Node[]{new Node(1), new Node(1)},
                new Node[]{new Node(3), new Node(3), new Node(3)}};
            DirectedGraph myGraph = new DirectedGraph();
            myGraph.BuildGraph(inputMatrix);
            List<List<Node>> foundPaths = new List<List<Node>>();
            myGraph.SearchMaxPaths(myGraph.nodes[0], new List<Node>(), foundPaths);
            Assert.AreEqual(0, foundPaths.Count);
        }

        [TestMethod]
        public void DirectedGraphTests_SearchMaxPathsWhereGraphIsEmpty()
        {
            List<Node[]> inputMatrix = new List<Node[]>();
            DirectedGraph myGraph = new DirectedGraph();
            myGraph.BuildGraph(inputMatrix);
            List<List<Node>> foundPaths = new List<List<Node>>();
            myGraph.SearchMaxPaths(myGraph.getRootNode(), new List<Node>(), foundPaths);
            Assert.AreEqual(0, foundPaths.Count);
        }

        [TestMethod]
        public void DirectedGraphTests_SearchMaxPathsWhereSuchPatInOneLineGraph()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)}};
            DirectedGraph myGraph = new DirectedGraph();
            myGraph.BuildGraph(inputMatrix);
            List<List<Node>> foundPaths = new List<List<Node>>();
            myGraph.SearchMaxPaths(myGraph.nodes[0], new List<Node>(), foundPaths);
            Assert.AreEqual(1, foundPaths.Count);
        }
    }
}