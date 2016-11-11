using System;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.CommandTests
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumenNullException_WhenProvidedParametersAreNull()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(null));
        }

        [Test]
        public void Execute_ShouldReturnCorrectValue_WhenValidArgumentsArePassed()
        {
            //Arrange
            const string expectedResult =
                "A new student with name Pesho Peshov, grade Second and ID 0 was created.";

            var mockedFactory = new Mock<IStudentFactory>();
            var mockStudentRepo = new Mock<IKeyedRepository<IStudent>>();
            var mockedEngine = new Mock<ISchoolSystemEngine>();
            mockedEngine.Setup(e => e.Data.Students).Returns(mockStudentRepo.Object);

            var parameters = new List<string>() { "Pesho", "Peshov", "2" };

            var command = new CreateStudentCommand(mockedFactory.Object);
            //Act
            var result = command.Execute(parameters, mockedEngine.Object.Data);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Execute_ShouldCallFactoryGetStudentMethodOnceWithCorrectParameters_WhenValidArgumentsArePassed()
        {
            //Arrange
            var parameters = new List<string>() { "Pesho", "Peshov", "2" };
            var mockedFactory = new Mock<IStudentFactory>();
            mockedFactory.Setup(f => f.GetStudent("Pesho", "Peshov", Grade.Second));
            var mockedEngine = new Mock<ISchoolSystemEngine>();
            var mockStudentRepo = new Mock<IKeyedRepository<IStudent>>();
            mockedEngine.Setup(e => e.Data.Students).Returns(mockStudentRepo.Object);
            var command = new CreateStudentCommand(mockedFactory.Object);
            //Act
            command.Execute(parameters, mockedEngine.Object.Data);
            //Assert
            mockedFactory.Verify(f => f.GetStudent("Pesho", "Peshov", Grade.Second), Times.Once());
        }

        [Test]
        public void Execute_ShouldCallIdGeneratorGetNextMethodExactlyOnce_WhenValidArgumentsArePassed()
        {
            //Arrange
            var parameters = new List<string>() { "Pesho", "Peshov", "2" };
            var mockedFactory = new Mock<IStudentFactory>();
            mockedFactory.Setup(f => f.GetStudent("Pesho", "Peshov", Grade.Second));

            var mockedEngine = new Mock<ISchoolSystemEngine>();

            var mockStudentRepo = new Mock<IKeyedRepository<IStudent>>();
            mockStudentRepo.SetupGet(s => s.NextId);
            mockedEngine.Setup(e => e.Data.Students).Returns(mockStudentRepo.Object);

            var command = new CreateStudentCommand(mockedFactory.Object);
            //Act
            command.Execute(parameters, mockedEngine.Object.Data);
            //Assert
            mockStudentRepo.Verify(e => e.NextId, Times.Once());
        }

        [Test]
        public void Execute_ShouldCallAddStudentMethodWithCorrectParametersExactlyOnce_WhenValidArgumentsArePassed()
        {
            //Arrange
            var parameters = new List<string>() { "Pesho", "Peshov", "2" };
            var mockedIdProvider = new Mock<IIdProvider>();
            mockedIdProvider.Setup(i => i.GetNext()).Returns(2);

            var mockedStudent = new Mock<IStudent>();
            var mockedFactory = new Mock<IStudentFactory>();
            mockedFactory.Setup(f => f.GetStudent("Pesho", "Peshov", Grade.Second))
                         .Returns(mockedStudent.Object);

            var mockedEngine = new Mock<ISchoolSystemEngine>();
            var mockStudentRepo = new Mock<IKeyedRepository<IStudent>>();
            mockedEngine.Setup(e => e.Data.Students).Returns(mockStudentRepo.Object);
            mockedEngine.Setup(e => e.Data.Students.Add(mockedStudent.Object));

            var command = new CreateStudentCommand(mockedFactory.Object);
            //Act
            command.Execute(parameters, mockedEngine.Object.Data);
            //Assert
            mockedEngine.Verify(e => e.Data.Students.Add(mockedStudent.Object), Times.Once());
        }

        [Test]
        public void Execute_ShouldThrowFormatException_WhenInvalidArgumentsArePassed()
        {
            //Arrange
            var mockedIdProvider = new Mock<IIdProvider>();
            mockedIdProvider.Setup(i => i.GetNext()).Returns(1);
            var mockedFactory = new Mock<IStudentFactory>();
            var mockStudentRepo = new Mock<IKeyedRepository<IStudent>>();
            var mockedEngine = new Mock<ISchoolSystemEngine>();
            mockedEngine.Setup(e => e.Data.Students).Returns(mockStudentRepo.Object);

            var parameters = new List<string>() { "Pesho", "Peshov", "NOT A VALID GRADE!!!!" };

            var command = new CreateStudentCommand(mockedFactory.Object);
            //Act & Assert
            Assert.Throws<FormatException>(() => command.Execute(parameters, mockedEngine.Object.Data));
        }

        [Test]
        public void Execute_ShouldThrowArgumentNullException_WhenNullArgumentsArePassed()
        {
            //Arrange
            var mockedIdProvider = new Mock<IIdProvider>();
            mockedIdProvider.Setup(i => i.GetNext()).Returns(1);
            var mockedFactory = new Mock<IStudentFactory>();
            var mockStudentRepo = new Mock<IKeyedRepository<IStudent>>();
            var mockedEngine = new Mock<ISchoolSystemEngine>();
            mockedEngine.Setup(e => e.Data.Students).Returns(mockStudentRepo.Object);

            var parameters = new List<string>() { "Pesho", "Peshov", null };

            var command = new CreateStudentCommand(mockedFactory.Object);
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => command.Execute(parameters, mockedEngine.Object.Data));
        }
    }
}
