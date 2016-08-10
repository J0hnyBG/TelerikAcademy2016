using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;

namespace Cosmetics.Tests2.Products
{
    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void Print_ShouldReturnStringInCorrectFormat()
        {
            var shampoo = new Shampoo("Name", "Brand", 0.5M, GenderType.Women, 500, UsageType.Medical);
            var expected = "- Brand - Name:\r\n  * Price: $250.0\r\n  * For gender: Women\r\n  * Quantity: 500 ml\r\n  * Usage: Medical";
            var result = shampoo.Print();

            Assert.AreEqual(expected, result);
        }
    }
}
