using System;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.CommandTests
{
    [TestFixture]
    public class TeacherAddMarkTests
    {
        [TestCase("a", "1", "5")]
        [TestCase("1", "sdas", "5")]
        [TestCase("1", "1", "asdasdsa")]
        [TestCase("@#!", "ASD", "asdasdsa")]
        public void Execute_ShouldThrowFormatException_WhenInvalidArgumentsArePassed(
            string teacherId,
            string studentId,
            string mark)
        {
            //Arrange
            var parameters = new List<string> { teacherId, studentId, mark };
            var mockedEngine = new Mock<ISchoolSystemEngine>();
            var command = new TeacherAddMarkCommand();
            //Act
            Assert.Throws<FormatException>(() => command.Execute(parameters, mockedEngine.Object.Data));
        }

        [TestCase(null, "1", "5")]
        [TestCase("1", null, "5")]
        [TestCase("1", "1", null)]
        [TestCase(null, null, null)]
        public void Execute_ShouldThrowArgumentNullException_WhenNullArgumentsArePassed(
            string teacherId,
            string studentId,
            string mark)
        {
            //Arrange
            var parameters = new List<string> { teacherId, studentId, mark };
            var mockedEngine = new Mock<ISchoolSystemEngine>();
            var command = new TeacherAddMarkCommand();
            //Act
            Assert.Throws<ArgumentNullException>(() => command.Execute(parameters, mockedEngine.Object.Data));
        }

        [Test]
        public void Execute_ShouldCallGetByIdMethodsWithCorrectParameters_WhenValidArgumentsArePassed()
        {
            //Arrange
            var parameters = new List<string> { "1", "1", "2" };
            var mockedStudent = new Mock<IStudent>();
            var mockedTeacher = new Mock<ITeacher>();

            var mockedEngine = new Mock<ISchoolSystemEngine>();
            mockedEngine.Setup(e => e.Data.Students.GetById(1))
                        .Returns(mockedStudent.Object);
            mockedEngine.Setup(e => e.Data.Teachers.GetById(1))
                        .Returns(mockedTeacher.Object);

            var command = new TeacherAddMarkCommand();
            //Act
            command.Execute(parameters, mockedEngine.Object.Data);
            //Assert
            mockedEngine.Verify(e => e.Data.Students.GetById(1), Times.Once);
            mockedEngine.Verify(e => e.Data.Teachers.GetById(1), Times.Once);
        }

        [Test]
        public void Execute_ShouldReturnCorrectValue_WhenValidArgumentsArePassed()
        {
            //Arrange
            const string Name = "Pesho";
            const string ExpectedMessage =
                "Teacher Pesho Pesho added mark 2 to student Pesho Pesho in Bulgarian.";
            var parameters = new List<string> { "1", "1", "2" };
            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(s => s.FirstName)
                         .Returns(Name);
            mockedStudent.Setup(s => s.LastName)
                         .Returns(Name);

            var mockedTeacher = new Mock<ITeacher>();
            mockedTeacher.Setup(s => s.FirstName)
                         .Returns(Name);
            mockedTeacher.Setup(s => s.LastName)
                         .Returns(Name);
            mockedTeacher.Setup(s => s.Subject)
                         .Returns(Subject.Bulgarian);

            var mockedEngine = new Mock<ISchoolSystemEngine>();
            mockedEngine.Setup(e => e.Data.Students.GetById(1))
                        .Returns(mockedStudent.Object);
            mockedEngine.Setup(e => e.Data.Teachers.GetById(1))
                        .Returns(mockedTeacher.Object);

            var command = new TeacherAddMarkCommand();
            //Act
            var result = command.Execute(parameters, mockedEngine.Object.Data);
            //Assert
            Assert.AreEqual(ExpectedMessage, result);
        }

        [TestCase("1", "1", "2")]
        [TestCase("2", "3", "5")]
        public void Execute_ShouldTeacherAddMarkMethodWithCorrectParameters_WhenValidArgumentsArePassed(
            string teacher,
            string student,
            string mark)
        {
            //Arrange
            var parameters = new List<string> { teacher, student, mark };
            var teacherId = int.Parse(teacher);
            var studentId = int.Parse(student);
            var parsedMark = float.Parse(mark);

            var mockedStudent = new Mock<IStudent>();
            var mockedTeacher = new Mock<ITeacher>();
            mockedTeacher.Setup(t => t.AddMark(mockedStudent.Object, parsedMark));

            var mockedEngine = new Mock<ISchoolSystemEngine>();
            mockedEngine.Setup(e => e.Data.Students.GetById(studentId))
                        .Returns(mockedStudent.Object);
            mockedEngine.Setup(e => e.Data.Teachers.GetById(teacherId))
                        .Returns(mockedTeacher.Object);


            var command = new TeacherAddMarkCommand();
            //Act
            command.Execute(parameters, mockedEngine.Object.Data);
            //Assert
            mockedTeacher.Verify(t => t.AddMark(mockedStudent.Object, parsedMark), Times.Once());
        }
    }
}
