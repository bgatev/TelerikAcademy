namespace Matrix
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetMatrixSizeFromConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("6{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Console.WriteLine("Enter a positive number between 0 and 100: ");
                    int n = int.Parse(Console.ReadLine());

                    string expected = string.Format("Enter a positive number between 0 and 100: {0}", Environment.NewLine);

                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void PrintMatrixToConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    int[,] matrix = new int[3, 3] 
                        { 
                            { 1, 7, 8 }, 
                            { 6, 2, 9 }, 
                            { 5, 4, 3 }
                        };

                    WalkInMatrix.PrintMatrix(matrix);

                    string expected = string.Format("   1   7   8{0}   6   2   9{0}   5   4   3{0}", Environment.NewLine);

                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void IsCellEmptyCheckTrue()
        {
            int[,] matrix = new int[2, 2] 
                { 
                    { 1, 0 }, 
                    { 3, 2 } 
                };

            bool result = WalkInMatrix.IsCellEmpty(matrix, 0, 1);

            Assert.AreEqual<bool>(true, result);
        }

        [TestMethod]
        public void IsCellEmptyCheckFalse()
        {
            int[,] matrix = new int[3, 3] 
                { 
                    { 1, 7, 8 }, 
                    { 6, 2, 9 }, 
                    { 5, 4, 3 }
                };

            bool result = WalkInMatrix.IsCellEmpty(matrix, 1, 1);

            Assert.AreEqual<bool>(false, result);
        }

        [TestMethod]
        public void FindNextEmptyCellTrue()
        {
            int[,] matrix = new int[3, 3] 
                { 
                    { 1, 0, 0 }, 
                    { 6, 2, 0 }, 
                    { 5, 4, 3 }
                };

            int[] result = WalkInMatrix.FindNextEmptyCell(matrix);

            Assert.AreEqual<int>(0, result[0], "Row is not OK");
            Assert.AreEqual<int>(1, result[1], "Col is not OK");
        }

        [TestMethod]
        public void FindNextEmptyCellFalse()
        {
            int[,] matrix = new int[3, 3] 
                {
                    { 1, 7, 8 }, 
                    { 6, 2, 9 }, 
                    { 5, 4, 3 }
                };

            int[] result = WalkInMatrix.FindNextEmptyCell(matrix);

            Assert.AreEqual<int>(0, result[0], "Row is not OK");
            Assert.AreEqual<int>(0, result[1], "Col is not OK");
        }
    }
}
