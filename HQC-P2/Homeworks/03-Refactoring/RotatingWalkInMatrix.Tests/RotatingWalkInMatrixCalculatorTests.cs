namespace RotatingWalkInMatrix.Tests
{
    using System;

    using NUnit.Framework;

    using WalkInMatrix;

    [TestFixture]
    public class RotatingWalkInMatrixCalculatorTests
    {
        [Test]
        public void Calculate_WhenInputIsValid_ShouldReturnCorrectResults()
        {
            var matrixSize = 6;
            var expected = new[,]
                           {
                               {1, 16, 17, 18, 19, 20},
                               {15, 2, 27, 28, 29, 21},
                               {14, 31, 3, 26, 30, 22},
                               {13, 36, 32, 4, 25, 23},
                               {12, 35, 34, 33, 5, 24},
                               {11, 10, 9, 8, 7, 6}
                           };

            int[,] result = RotatingWalkInMatrixCalculator.Calculate(matrixSize);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_WhenInputIsLessThanZero_ShouldThrowArgumentOutOfRangeExceptionWithCorrectMessage()
        {
            var matrixSize = -1;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => RotatingWalkInMatrixCalculator.Calculate(matrixSize));
            StringAssert.Contains("Matrix size must be", ex.Message);
        }
    }
}
