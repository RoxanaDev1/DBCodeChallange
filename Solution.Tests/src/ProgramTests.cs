
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solution.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ProgramTests_RunSolution_NoExceptionsOnValidInput()
        {
            string fileLocation = "../../../src/input/input1.txt";
            try
            {
                Program.RunSolution(fileLocation);
            }
            catch (Exception ex)
            {
                Assert.Fail($"no exception should be thrown {ex}");
            }
        }

        [TestMethod]
        public void ProgramTests_RunSolution_CatchFileNotFound()
        {
            string fileLocation = "../../../src/input/input10.txt";
            try
            {
                Program.RunSolution(fileLocation);
            }
            catch (FileNotFoundException ex)
            {
                Assert.Fail($"Exception should be handled {ex}");
            }
        }

        [TestMethod]
        public void ProgramTests_RunSolution_CatchFilePathIsEmpty()
        {
            string fileLocation = "";
            try
            {
                Program.RunSolution(fileLocation);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail($"Exception should be handled {ex}");
            }
        }

        [TestMethod]
        public void ProgramTests_RunSolution_CatchInvalidInputException()
        {
            string fileLocation = "../../../src/input/input4.txt";
            try
            {
                Program.RunSolution(fileLocation);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception should be handled {ex}");
            }
        }

        [TestMethod]
        public void ProgramTests_RunSolution_CatchInvalidInputMatrixException()
        {
            string fileLocation = "../../../src/input/input5.txt";
            try
            {
                Program.RunSolution(fileLocation);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception should be handled {ex}");
            }
        }
    }
}