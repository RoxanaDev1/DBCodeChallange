using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solution.Tests
{
    [TestClass]
    public class CreateInputMatrix_UtilsTests
    {

        [TestMethod]
        public void CreateInputMatrix_CreatesAnInputMatrixForValidInput()
        {
            string fileLocation = "../../../input/input1.txt";
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
            string fileLocation = "../../../input/input2.txt";
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
            string fileLocation = "../../../input/input2.txt";
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
            string fileLocation = "../../../input/input3.txt";
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
}

