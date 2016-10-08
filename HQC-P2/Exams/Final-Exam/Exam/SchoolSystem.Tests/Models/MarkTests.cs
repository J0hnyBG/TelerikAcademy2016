namespace SchoolSystem.Tests.Models
{
    using System;

    using SchoolSystem.Models;

    using NUnit.Framework;

    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void Ctor_WhenPassedValuesAreValid_ShouldReturnCorrectMarkObject()
        {
            var mark = new Mark(Subject.Bulgarian, 4);

            Assert.AreEqual(Subject.Bulgarian, mark.Subject);
            Assert.AreEqual(4, mark.Value);
        }

        [TestCase(1)]
        [TestCase(7)]
        public void Ctor_WhenPassedValuesAreInValid_ShouldThrowArgumentOutOfRangeExceptionWithCorrectMessage(int incorrectValue)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Mark(Subject.Bulgarian, incorrectValue));

            StringAssert.Contains("Mark value must be between", ex.Message);
        }
    }
}
