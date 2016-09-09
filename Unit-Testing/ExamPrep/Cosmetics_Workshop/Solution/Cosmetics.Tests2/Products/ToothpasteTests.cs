using System.Collections.Generic;
using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;

namespace Cosmetics.Tests2.Products
{
    [TestFixture]
    public class ToothpasteTests
    {
        [Test]
        public void Print_ShouldReturnStringInCorrectFormat()
        {
            var toothpaste = new Toothpaste("Name", "Brand", 0.5M, GenderType.Women, new List<string>() {"sugar", "spice"});
            var expected = "- Brand - Name:\r\n  * Price: $250.0\r\n  * For gender: Women\r\n  * Quantity: 500 ml\r\n  * Usage: Medical";
            var result = toothpaste.Print();

            Assert.AreEqual(expected, result);
        }
    }
}
