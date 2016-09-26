namespace RotatingWalkInMatrix.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using WalkInMatrix;
    using WalkInMatrix.Calculator;

    [TestFixture]
    public class RotatingWalkInMatrixCalculatorTests
    {
        private static readonly IList<int[,]> CorrectResultsList = new List<int[,]>
                                                                   {
                                                                       new[,]
                                                                       {
                                                                           {1, 7, 8},
                                                                           {6, 2, 9},
                                                                           {5, 4, 3}
                                                                       },
                                                                       new[,]
                                                                       {
                                                                           {1, 16, 17, 18, 19, 20},
                                                                           {15, 2, 27, 28, 29, 21},
                                                                           {14, 31, 3, 26, 30, 22},
                                                                           {13, 36, 32, 4, 25, 23},
                                                                           {12, 35, 34, 33, 5, 24},
                                                                           {11, 10, 9, 8, 7, 6}
                                                                       },
                                                                       new[,]
                                                                       {
                                                                           {1, 25, 26, 27, 28, 29, 30, 31, 32},
                                                                           {24, 2, 45, 46, 47, 48, 49, 50, 33},
                                                                           {23, 61, 3, 44, 57, 58, 59, 51, 34},
                                                                           {22, 75, 62, 4, 43, 56, 60, 52, 35},
                                                                           {21, 74, 76, 63, 5, 42, 55, 53, 36},
                                                                           {20, 73, 81, 77, 64, 6, 41, 54, 37},
                                                                           {19, 72, 80, 79, 78, 65, 7, 40, 38},
                                                                           {18, 71, 70, 69, 68, 67, 66, 8, 39},
                                                                           {17, 16, 15, 14, 13, 12, 11, 10, 9}
                                                                       }
                                                                   };

        [TestCaseSource(nameof(CorrectResultsList))]
        public void Calculate_WhenInputIsValid_ShouldReturnCorrectResults(int[,] expected)
        {
            var validMatrixSize = expected.GetLength(0);

            var result = RotatingWalkInMatrixCalculator.Calculate(validMatrixSize);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_WhenInputIsLessThanZero_ShouldThrowArgumentOutOfRangeExceptionWithCorrectMessage()
        {
            var invalidMatrixSize = -1;

            var ex =
                Assert.Throws<ArgumentOutOfRangeException>(() => RotatingWalkInMatrixCalculator.Calculate(invalidMatrixSize));
            StringAssert.Contains("Matrix size", ex.Message);
        }
    }
}
