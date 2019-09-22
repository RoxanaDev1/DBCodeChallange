using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = args.Length > 0 ? args[0] : "./Solution/src/input/input2.txt";
            Program.RunSolution(fileLocation);
        }

        public static void RunSolution(string fileLocation)
        {
            try
            {
                List<Node[]> inputMatrix = Utils.CreateInputMatrix(fileLocation);

                DirectedGraph myGraph = new DirectedGraph();
                myGraph.BuildGraph(inputMatrix);

                List<List<Node>> foundPaths = new List<List<Node>>();
                myGraph.SearchMaxPaths(myGraph.getRootNode(), new List<Node>(), foundPaths);

                decimal maxSum = Utils.GetMaxSum(foundPaths);

                Console.WriteLine($"Max sum: {maxSum}");
                Console.Write($"Path: ");
                Utils.GetMaxPath(foundPaths).ForEach(node => Console.Write($"{node.weight},"));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found. Exception {e}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"File path cannot be empty. Exception {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception thrown. Exception {e.Message}");
            }
        }
    }
}