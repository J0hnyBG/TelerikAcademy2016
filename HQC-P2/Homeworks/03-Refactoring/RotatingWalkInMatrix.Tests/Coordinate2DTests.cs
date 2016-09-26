namespace RotatingWalkInMatrix.Tests
{
    using NUnit.Framework;
    using WalkInMatrix.Models;

    [TestFixture]
    public class Coordinate2DTests
    {
        [Test]
        public void Zero_ShouldReturnPointWithValuesEqualToZero()
        {
            var expectedRowsAndCols = 0;

            var result = Coordinate2D.Zero;

            Assert.AreEqual(expectedRowsAndCols, result.Row);
            Assert.AreEqual(expectedRowsAndCols, result.Col);
        }

        [Test]
        public void Costructor_ShouldReturnPointWithValuesEqualToZero_WhenNoValuesArePassed()
        {
            var expectedRowsAndCols = 0;

            var result = new Coordinate2D();

            Assert.AreEqual(expectedRowsAndCols, result.Row);
            Assert.AreEqual(expectedRowsAndCols, result.Col);
        }

        [TestCase(5, 3)]
        [TestCase(-5, 3)]
        [TestCase(0, -5)]
        public void Costructor_ShouldReturnPointWithCorrectValues_WhenValidArgumentsArePassed(int rows, int cols)
        {
            var expectedRows = rows;
            var expectedCols = cols;

            var result = new Coordinate2D(expectedRows, expectedCols);

            Assert.AreEqual(expectedRows, result.Row);
            Assert.AreEqual(expectedCols, result.Col);
        }
    }
}
