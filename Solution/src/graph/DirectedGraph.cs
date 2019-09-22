using System;
using System.Collections.Generic;

namespace Solution
{
    public class DirectedGraph
    {
        //A list of all the nodes which are used in this graph.
        public List<Node> nodes { get; private set; }
        //A number defining what is a maximum path length. This number is the number of triangle lines in the input.
        public int maxLength { get; private set; }

        /// <summary>
        /// Empty constructor of a DirectedGraph 
        /// </summary>
        /// <returns>
        /// An empty graph with node nodes, and max path length of 0.
        /// </returns>
        public DirectedGraph()
        {
            this.nodes = new List<Node>();
            this.maxLength = 0;
        }

        /// <summary>
        /// Function which accepts a list of node arrays called inputMatrix.
        /// </summary>
        /// <param name="inputMatrix">A "2D" representation of the triagle input</param>
        /// <returns>
        /// A graph representation of the the input matrix given.
        /// </returns>
        public void BuildGraph(List<Node[]> inputMatrix)
        {
            if (!Utils.isValidInputMatrix(inputMatrix))
            {
                throw new Exception("Build graph could not build as input matrix is invalid");
            }
            this.nodes = new List<Node>();
            this.maxLength = inputMatrix.Count;
            int listIndex = 1;
            inputMatrix.ForEach(line =>
            {
                bool lastLine = (listIndex == inputMatrix.Count);
                for (int i = 0; i < line.Length; i++)
                {
                    if (!lastLine)
                    {
                        Node[] nextLine = inputMatrix[listIndex];
                        line[i].AddNeighbor(nextLine[i]);
                        line[i].AddNeighbor(nextLine[i + 1]);
                    }
                    else
                    {
                        line[i].isLast = true;
                    }
                    this.nodes.Add(line[i]);
                };
                listIndex++;
            });
        }

        /// <summary>
        /// A method to pring a short overview of this graph.
        /// </summary>
        public void PrintGraph()
        {
            this.nodes.ForEach(node =>
            {
                Console.WriteLine($" I have {node.neighbors.Count} neighbours, my weight is {node.weight}");
                node.neighbors.ForEach(i => Console.Write($"{i.weight},"));
                Console.WriteLine();
            });
        }

        /// <summary>
        /// Function which returns the root node of the graph based on its triangle input.
        /// </summary>
        /// <returns>
        /// The node which is the root of the graph, or null.
        /// </returns>
        public Node GetRootNode()
        {
            if (this.nodes.Count == 0)
            {
                return null;
            }
            return this.nodes[0];

        }
        /// <summary>
        /// A method which searches the graph for the maximum path.
        /// Maximum path is defined by a path which reaches the bottom of the input triangle.
        /// This method is based on recursive DFS search for a graph.
        /// </summary>
        /// <param name="node">The node which we are currently at. The initial one is the top of the triangle input.</param>
        /// <param name="paths">A list which contains the current path which is being explored.</param>
        /// <param name="savePath">A list of node lists which are the maximum paths found</param>
        public void SearchMaxPaths(Node node, List<Node> paths, List<List<Node>> savePath)
        {
            if (node == null)
            {
                return;
            }

            paths.Add(node);
            if (node.neighbors.Count > 0)
            {
                node.neighbors.ForEach(currentNode => SearchMaxPaths(currentNode, paths, savePath));
                //When returning from the search remove this node from path, to make place for the new path nodes
                paths.Remove(node);
            }
            else if (node.isLast)
            {
                List<Node> copyList = new List<Node>(paths);
                savePath.Add(copyList);
                paths.ForEach(i => Console.Write("{0},", i.weight));
                Console.WriteLine($"PATH FOUND {paths.Count} {savePath.Count}!");
                //After full path found, remove the node to make place for another path.
                paths.Remove(node);
            }
            else
            {
                //Dead end, remove the element not have not needed elements in the path.
                paths.Remove(node);
            }
        }
    }
}