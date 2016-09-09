using System;
using Cosmetics.Common;
using NUnit.Framework;

namespace Cosmetics.Tests2.Common
{
    [TestFixture]
    public class CommonValidatorTests
    {
        [Test]
        public void CheckIfNull_WhenParamIsNull_ShouldThrowNullReferenceException()
        {
            object obj = null;

            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void CheckIfNull_WhenParamIsNotNull_ShouldNotThrowNullReferenceException()
        {
            var obj = new object();

            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckIfStringIsNullOrEmpty_WhenTextIsNullOrEmpty_ShouldThrowNullReferenceException(string text)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [TestCase("TheTextIsNotNullOrEmpty")]
        [TestCase("   ")]
        public void CheckIfStringIsNullOrEmpty_WhenTextIsNotNullOrEmpty_ShouldNotThrowNullReferenceException(string text)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [TestCase("", 1, 10)]
        [TestCase("I am invalid!TextIsToo long!!!", 2, 5)]
        public void CheckIfStringLengthIsValid_WhenLengthIsInvalid_ShouldThrowIndexOutOfRangeException(string text, int min, int max)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [TestCase("", 0, 10)]
        [TestCase("I am Valid!TextIsToo long!!!", 2, 50)]
        public void CheckIfStringLengthIsValid_WhenLengthIsValid_ShouldNotThrowIndexOutOfRangeException(string text, int min, int max)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}
