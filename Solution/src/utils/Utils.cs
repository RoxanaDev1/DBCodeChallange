using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solution;
public static class Utils
{

    /// <summary>
    /// Builds an input matrix from a given file input.
    /// The input matrix is a 2D representation of the triangle input.
    /// The method also handles file not found issues.
    /// </summary>
    /// <param name="fileLocation">A string which holds the location of the file.</param>
    /// <returns>
    /// A list of node array - 2D representation of the input called input matrix.
    /// </returns>
    public static List<Node[]> CreateInputMatrix(string fileLocation)
    {
        try
        {
            List<string> lines = File.ReadLines(fileLocation).ToList();
            if (lines.Count == 0)
            {
                throw new Exception("There is no input to process, file is empty");
            }
            List<Node[]> inputMatrix = new List<Node[]>();
            int i = 0;
            lines.ForEach(line =>
            {
                line = line.Trim();
                inputMatrix.Insert(i, GetNodeArray(line));
                i++;
            });
            return inputMatrix;
        }
        catch (FileNotFoundException e)
        {
            throw new System.Exception($"File not found. Exception {e}");
        }
        catch (ArgumentException e)
        {
            throw new System.Exception($"File path cannot be empty. Exception {e}");
        }
        catch (Exception e)
        {
            throw new System.Exception($"{e.Message}");
        }
    }

    /// <summary>
    /// Builds a node array from a line of string values.
    /// </summary>
    /// <param name="line">A line from the triangle containing numbers as strings.</param>
    /// <returns>
    /// A node array, containing the values given in the line.
    /// </returns>
    public static Node[] GetNodeArray(string line)
    {
        if (line.Length == 0)
        {
            return new Node[0];
        }
        int[] arr = Array.ConvertAll(line.Split(" "), s => int.Parse(s));
        Node[] nodeLine = new Node[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            nodeLine[i] = new Node(arr[i]);
        }
        return nodeLine;
    }

    /// <summary>
    /// Returns the maximum found sum of a list of found paths lists.
    /// </summary>
    /// <param name="foundPaths">A list of path lists. A path is a list of nodes.</param>
    /// <returns>
    /// A decimal number which is the max sum of weights in the found paths.
    /// </returns>
    public static decimal GetMaxSum(List<List<Node>> foundPaths)
    {
        if (foundPaths.Count == 0)
        {
            return 0;
        }
        decimal[] sumArr = new decimal[foundPaths.Count];
        int i = 0;
        foundPaths.ForEach(path => { sumArr[i] = path.Sum(node => node.weight); i++; });
        return sumArr.Max();
    }

    /// <summary>
    /// Returns the path which has the max sum.
    /// </summary>
    /// <param name="foundPaths">A list of path lists. A path is a list of nodes.</param>
    /// <returns>
    /// The list of nodes in the foundPaths with the maximum sum.
    /// </returns>
    public static List<Node> GetMaxPath(List<List<Node>> foundPaths)
    {
        if (foundPaths.Count == 0)
        {
            return new List<Node>();
        }
        decimal[] sumArr = new decimal[foundPaths.Count];
        int i = 0;
        foundPaths.ForEach(path => { sumArr[i] = path.Sum(node => node.weight); i++; });
        int maxIndex = sumArr.ToList().IndexOf(sumArr.Max());
        return foundPaths[maxIndex];
    }
}