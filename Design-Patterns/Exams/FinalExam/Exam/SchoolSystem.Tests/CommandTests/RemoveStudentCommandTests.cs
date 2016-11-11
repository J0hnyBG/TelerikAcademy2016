using System;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Tests.CommandTests
{
    [TestFixture]
    public class RemoveStudentCommandTests
    {
        [Test]
        public void Execute_ShouldReturnCorrectValue_WhenValidArgumentsArePassed()
        {
            //Arrange
            const string ExpectedReturnValue = "Student with ID 1 was sucessfully removed.";

            var parameters = new List<string>() { "1" };
            var mockEngine = new Mock<ISchoolSystemEngine>();
            mockEngine.Setup(e => e.Data.Students.Remove(1));

            var command = new RemoveStudentCommand();
            //Act
            var result = command.Execute(parameters, mockEngine.Object.Data);
            //Assert
            Assert.AreEqual(ExpectedReturnValue, result);
        }

        [Test]
        public void Execute_ShouldCallEngineRemoveStudentWithCorrectParameters_WhenValidArgumentsArePassed()
        {
            //Arrange
            var parameters = new List<string>() { "1" };
            var mockEngine = new Mock<ISchoolSystemEngine>();
            mockEngine.Setup(e => e.Data.Students.Remove(1));

            var command = new RemoveStudentCommand();
            //Act
            command.Execute(parameters, mockEngine.Object.Data);
            //Assert
            mockEngine.Verify(e => e.Data.Students.Remove(1), Times.Once());
        }

        [Test]
        public void Execute_ShouldThrowFormatException_WhenInvalidArgumentsArePassed()
        {
            //Arrange
            var parameters = new List<string>() { "I'm not a valid number!" };
            var mockEngine = new Mock<ISchoolSystemEngine>();

            var command = new RemoveStudentCommand();
            //Assert & Act
            Assert.Throws<FormatException>(() => command.Execute(parameters, mockEngine.Object.Data));
        }

        [Test]
        public void Execute_ShouldThrowArgumentNull_WhenNullArgumentsArePassed()
        {
            //Arrange
            var parameters = new List<string>() { null };
            var mockEngine = new Mock<ISchoolSystemEngine>();

            var command = new RemoveStudentCommand();
            //Assert & Act
            Assert.Throws<ArgumentNullException>(() => command.Execute(parameters, mockEngine.Object.Data));
        }
    }
}
