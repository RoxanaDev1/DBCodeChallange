using System;
using System.Collections.Generic;

namespace DBCodeChallange
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Node[]> inputMatrix = Utils.CreateInputMatrix("./src/input/input2.txt");

            DirectedGraph myGraph = new DirectedGraph(inputMatrix);

            List<List<Node>> foundPaths = new List<List<Node>>();
            myGraph.SearchMaxPaths(myGraph.nodes[0], new List<Node>(), new List<Node>(), foundPaths);

            decimal maxSum = Utils.GetMaxSum(foundPaths);

            Console.WriteLine($"Max sum: {maxSum}");
            Console.Write($"Path: ");
            Utils.GetMaxPath(foundPaths).ForEach(node => Console.Write($"{node.weight},"));
        }
    }
}