using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solution.Tests
{
    [TestClass]
    public class CreateInputMatrix_UtilsTests
    {

        [TestMethod]
        public void CreateInputMatrix_CreatesAnInputMatrixForValidInput()
        {
            string fileLocation = "../../../src/input/input1.txt";
            int expectedMatrixLines = 3;
            List<Node[]> inputMatrix = Utils.CreateInputMatrix(fileLocation);
            Assert.AreEqual(inputMatrix.Count, expectedMatrixLines);
            Assert.AreEqual(inputMatrix[0].Length, 1);
            Assert.AreEqual(inputMatrix[1].Length, 2);
            Assert.AreEqual(inputMatrix[2].Length, 3);
        }

        [TestMethod]
        public void CreateInputMatrix_ThrowExceptionForEmptyInput()
        {
            string fileLocation = "../../../src/input/input2.txt";
            try
            {
                List<Node[]> inputMatrix = Utils.CreateInputMatrix(fileLocation);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }

        [TestMethod]
        public void CreateInputMatrix_ThrowExceptionForFileNotFound()
        {
            string fileLocation = "../no.file";
            try
            {
                List<Node[]> inputMatrix = Utils.CreateInputMatrix(fileLocation);
                Assert.Fail("no exception thrown");
            }
            catch (FileNotFoundException ex)
            {
                Assert.IsTrue(ex is FileNotFoundException);
            }
        }

        [TestMethod]
        public void CreateInputMatrix_ThrowExceptionForEmptyFilePath()
        {
            string fileLocation = "";
            try
            {
                List<Node[]> inputMatrix = Utils.CreateInputMatrix(fileLocation);
                Assert.Fail("no exception thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex is ArgumentException);
            }
        }

        [TestMethod]
        public void CreateInputMatrix_CatchesExceptionForInvalidLineInput()
        {
            string fileLocation = "../../../src/input/input2.txt";
            try
            {
                List<Node[]> inputMatrix = Utils.CreateInputMatrix(fileLocation);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is System.Exception);
            }
        }

        [TestMethod]
        public void CreateInputMatrix_HandlesSpacesInEndOfLines()
        {
            string fileLocation = "../../../src/input/input3.txt";
            try
            {
                List<Node[]> inputMatrix = Utils.CreateInputMatrix(fileLocation);
            }
            catch (Exception ex)
            {
                Assert.Fail("no exception should be thrown, input should be handled", ex);
            }
        }
    }

    [TestClass]
    public class isValidInputMatrix_UtilsTests
    {
        [TestMethod]
        public void isValidInputMatrix_ReturnsTrueForValidMatrix()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)},
                new Node[]{new Node(5), new Node(6)},
                new Node[]{new Node(10), new Node(20), new Node(30)}};
            Assert.IsTrue(Utils.isValidInputMatrix(inputMatrix));
        }

        [TestMethod]
        public void isValidInputMatrix_ReturnsTrueForValidEmptyMatrix()
        {
            List<Node[]> inputMatrix = new List<Node[]>();
            Assert.IsTrue(Utils.isValidInputMatrix(inputMatrix));
        }

        [TestMethod]
        public void isValidInputMatrix_ReturnsTrueForValidOneLineMatrix()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)}};
            Assert.IsTrue(Utils.isValidInputMatrix(inputMatrix));
        }

        [TestMethod]
        public void isValidInputMatrix_ReturnsFalseForMultipleLineInvalidMatrix()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0)},
                new Node[]{new Node(5), new Node(6)},
                new Node[]{new Node(10), new Node(20), new Node(30), new Node(30)}};
            Assert.IsFalse(Utils.isValidInputMatrix(inputMatrix));
        }

        [TestMethod]
        public void isValidInputMatrix_ReturnsFalseForSingleLineInvalidMatrix()
        {
            List<Node[]> inputMatrix = new List<Node[]>{
                new Node[]{new Node(0), new Node(0), new Node(0)}};
            Assert.IsFalse(Utils.isValidInputMatrix(inputMatrix));
        }
    }

    [TestClass]
    public class GetNodeArray_UtilsTests
    {
        [TestMethod]
        public void GetNodeArray_CreatesANodeArray()
        {
            string line = "0 1 2";
            Node[] expectedArray = { new Node(0), new Node(1), new Node(2) };
            Node[] resultArray = Utils.GetNodeArray(line);
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i].weight, resultArray[i].weight);
            }
        }

        [TestMethod]
        public void GetNodeArray_ReturnsEmptyNodeArrayWhenLineIsEmpty()
        {
            string line = "";
            Assert.AreEqual(Utils.GetNodeArray(line).Length, 0);
        }

        [TestMethod]
        public void GetNodeArray_ThrowsExceptionIfLineIsInvalid()
        {
            string line = "a 1 2";
            try
            {
                Utils.GetNodeArray(line);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }
    }

    [TestClass]
    public class GetMaxSum_UtilsTests
    {
        [TestMethod]
        public void GetMaxSum_ReturnsTheCorrectMaxSum()
        {
            List<List<Node>> foundPaths = new List<List<Node>>{
                new List<Node>{ new Node(0), new Node(1), new Node(2) },
                new List<Node>{ new Node(5), new Node(6), new Node(7) },
                new List<Node>{ new Node(10), new Node(20), new Node(30) }};
            decimal expctedSum = 60;

            Assert.AreEqual(expctedSum, Utils.GetMaxSum(foundPaths));
        }

        [TestMethod]
        public void GetMaxSum_ReturnsTheCorrectMaxSumEvenIfTwoPathsHaveSameSum()
        {
            List<List<Node>> foundPaths = new List<List<Node>>{
                new List<Node>{ new Node(0), new Node(1), new Node(2) },
                new List<Node>{ new Node(20), new Node(20), new Node(20) },
                new List<Node>{ new Node(10), new Node(20), new Node(30) }};
            decimal expctedSum = 60;

            Assert.AreEqual(expctedSum, Utils.GetMaxSum(foundPaths));
        }

        [TestMethod]
        public void GetMaxSum_ReturnsZeroIfNoPathIsFound()
        {
            List<List<Node>> foundPaths = new List<List<Node>> { };
            decimal expctedSum = 0;

            Assert.AreEqual(expctedSum, Utils.GetMaxSum(foundPaths));
        }
    }

    [TestClass]
    public class GetMaxPath_UtilsTests
    {
        [TestMethod]
        public void GetMaxPath_ReturnsTheCorrectMaxPath()
        {
            List<List<Node>> foundPaths = new List<List<Node>>{
                new List<Node>{ new Node(0), new Node(1), new Node(2) },
                new List<Node>{ new Node(5), new Node(6), new Node(7) },
                new List<Node>{ new Node(10), new Node(20), new Node(30) }};
            List<Node> maxPath = Utils.GetMaxPath(foundPaths);

            for (int i = 0; i < maxPath.Count; i++)
            {
                Assert.AreEqual(maxPath[i].weight, foundPaths[2][i].weight);
            }
        }

        [TestMethod]
        public void GetMaxPath_ReturnsTheFirstMaxPathEvenIfTwoPathsHaveSameSum()
        {
            List<List<Node>> foundPaths = new List<List<Node>>{
                new List<Node>{ new Node(0), new Node(1), new Node(2) },
                new List<Node>{ new Node(20), new Node(20), new Node(20) },
                new List<Node>{ new Node(10), new Node(20), new Node(30) }};
            List<Node> maxPath = Utils.GetMaxPath(foundPaths);

            for (int i = 0; i < maxPath.Count; i++)
            {
                Assert.AreEqual(maxPath[i].weight, foundPaths[1][i].weight);
            }
        }

        [TestMethod]
        public void GetMaxPath_ReturnEmptyListIfNoPathIsFound()
        {
            List<List<Node>> foundPaths = new List<List<Node>> { };

            Assert.AreEqual(0, Utils.GetMaxPath(foundPaths).Count);
        }
    }
}

