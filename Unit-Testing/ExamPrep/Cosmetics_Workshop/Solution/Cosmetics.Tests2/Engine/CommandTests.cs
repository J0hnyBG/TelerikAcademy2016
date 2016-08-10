using System;
using System.Linq;
using Cosmetics.Engine;
using NUnit.Framework;

namespace Cosmetics.Tests2.Engine
{
    [TestFixture]
    public class CommandTests
    {
        [TestCase("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma")]
        [TestCase("CreateCategory ForMale")]
        [TestCase("AddToCategory ForMale White-")]
        [TestCase("TotalPrice")]
        public void Parse_WhenParamIsValid_ShouldReturnNewCommandObject(string commandString)
        {
            var result = Command.Parse(commandString);

            Assert.IsInstanceOf<Command>(result);
        }

        [TestCase("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma", "CreateToothpaste")]
        [TestCase("CreateCategory ForMale", "CreateCategory")]
        [TestCase("AddToCategory ForMale White-", "AddToCategory")]
        [TestCase("TotalPrice", "TotalPrice")]
        public void Parse_WhenParamIsValid_ShouldReturnCommandObjectWithCorrectName(string commandString, string name)
        {
            var result = Command.Parse(commandString);

            Assert.AreEqual(name, result.Name);
        }

        [TestCase("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma", "White+ Colgate 15.50 men fluor,bqla,golqma")]
        [TestCase("CreateCategory ForMale", "ForMale")]
        [TestCase("AddToCategory ForMale White-", "ForMale White-")]
        public void Parse_WhenParamIsValid_ShouldReturnCommandObjectWithCorrectParameters(string commandString, string parameters)
        {
            var parameterList = parameters.Split(' ').ToList();

            var result = Command.Parse(commandString).Parameters;

            CollectionAssert.AreEqual(parameterList, result);
        }

        [Test]
        public void Parse_WhenParamIsNull_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void Parse_WhenCommandNameIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            const string invalidInput = "  White+";

            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(invalidInput));
            StringAssert.Contains("Name", ex.Message);
        }

        [Test]
        public void Parse_WhenCommandParametersAreNullOrEmpty_ShouldThrowArgumentNullException()
        {
            const string invalidInput = "CreateToothpaste      ";

            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(invalidInput));
            StringAssert.Contains("List", ex.Message);
        }
    }
}
