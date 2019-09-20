using System;
using System.Collections.Generic;

namespace DBCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = (args != null && args[0].Length > 0) ? "./src/input/input1.txt" : args[0];
            List<Node[]> inputMatrix = Utils.CreateInputMatrix(fileLocation);

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