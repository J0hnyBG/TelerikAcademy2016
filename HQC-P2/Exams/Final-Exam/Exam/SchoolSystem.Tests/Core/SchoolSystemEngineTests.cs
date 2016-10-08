namespace SchoolSystem.Tests.Core
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Assert = NUnit.Framework.Assert;
    using StringAssert = NUnit.Framework.StringAssert;
    using NUnit.Framework;

    using SchoolSystem.Core;
    using SchoolSystem.Contracts;

    [TestFixture]
    public class SchoolSystemEngineTests
    {
        [Test]
        public void Ctor_WhenValidParamsArePassed_ShouldReturnCorrectSchoolSystemEngineObject()
        {
            var mockedReader = new Mock<IReader>();
            var mockedWriter = new Mock<IWriter>();
            var teachers = new Dictionary<int, ITeacher>();
            var students = new Dictionary<int, IStudent>();
            var mockedCommandFactory = new Mock<ICommandFactory>();

            var result = new SchoolSystemEngine(
                mockedReader.Object, 
                mockedWriter.Object, 
                teachers, 
                students,
                mockedCommandFactory.Object);
            var privateObjectResult = new PrivateObject(result);

            Assert.AreSame(mockedCommandFactory.Object, privateObjectResult.GetField("commandFactory"));
            Assert.AreSame(mockedReader.Object, privateObjectResult.GetField("reader"));
            Assert.AreSame(mockedWriter.Object, privateObjectResult.GetField("writer"));
            Assert.AreSame(teachers, SchoolSystemEngine.Teachers);
            Assert.AreSame(students, SchoolSystemEngine.Students);
        }

        [Test]
        public void AddTeacher_ShouldAddTeacherToListOfTeachers()
        {
            var expectedId = 10;
            var mockedTeacher = new Mock<ITeacher>();

            SchoolSystemEngine.AddTeacher(expectedId, mockedTeacher.Object);

            Assert.AreSame(SchoolSystemEngine.Teachers[expectedId], mockedTeacher.Object);
        }

        [Test]
        public void AddTeacher_WhenIdIsInvalid_ShouldThrowArgumentOutOfRangeException()
        {
            var invalidID = -1;
            var mockedTeacher = new Mock<ITeacher>();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => SchoolSystemEngine.AddTeacher(invalidID, mockedTeacher.Object));
            StringAssert.Contains("cannot be less than 0!", ex.Message);
        }

        [Test]
        public void AddTeacher_WhenTeacherIsNull_ShouldThrowArgumentNullException()
        {
            var id = 100;
            ITeacher nullTeacher = null;

            var ex = Assert.Throws<ArgumentNullException>(() => SchoolSystemEngine.AddTeacher(id, nullTeacher));
            StringAssert.Contains("cannot be null or empty", ex.Message);
        }

        [Test]
        public void RemoveTeacher_ShouldRemoveAddedTeacherFromList()
        {
            var expectedId = 11;
            var mockedTeacher = new Mock<ITeacher>();
            SchoolSystemEngine.AddTeacher(expectedId, mockedTeacher.Object);

            SchoolSystemEngine.RemoveTeacher(expectedId);

            Assert.IsFalse(SchoolSystemEngine.Teachers.ContainsKey(expectedId));
        }

        [Test]
        public void AddStudent_ShouldAddStudentToListOfStudent()
        {
            var expectedId = 10;
            var mockedStudent = new Mock<IStudent>();

            SchoolSystemEngine.AddStudent(expectedId, mockedStudent.Object);

            Assert.AreSame(SchoolSystemEngine.Students[expectedId], mockedStudent.Object);
        }

        [Test]
        public void AddStudent_WhenIdIsInvalid_ShouldThrowArgumentOutOfRangeException()
        {
            var invalidID = -1;
            var mockedStudent = new Mock<IStudent>();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => SchoolSystemEngine.AddStudent(invalidID, mockedStudent.Object));
            StringAssert.Contains("cannot be less than 0!", ex.Message);
        }

        [Test]
        public void AddStudent_WhenStudentIsNull_ShouldThrowArgumentNullException()
        {
            var id = 100;
            IStudent nullStudent = null;

            var ex = Assert.Throws<ArgumentNullException>(() => SchoolSystemEngine.AddStudent(id, nullStudent));
            StringAssert.Contains("cannot be null or empty", ex.Message);
        }

        [Test]
        public void RemoveStudent_ShouldRemoveStudentInStudents()
        {
            var expectedId = 11;
            var mockedStudent = new Mock<IStudent>();
            SchoolSystemEngine.AddStudent(expectedId, mockedStudent.Object);

            SchoolSystemEngine.RemoveStudent(expectedId);

            Assert.IsFalse(SchoolSystemEngine.Students.ContainsKey(expectedId));
        }

        [Test]
        public void Start_ShouldCallReadLineOnceAndReturn_WhenEndCommandIsRead()
        {
            var mockedWriter = new Mock<IWriter>();
            var teachers = new Dictionary<int, ITeacher>();
            var students = new Dictionary<int, IStudent>();
            var mockedCommandFactory = new Mock<ICommandFactory>();

            var mockedReader = new Mock<IReader>();
            mockedReader.Setup(x => x.ReadLine()).Returns("End");

            var result = new SchoolSystemEngine(
                mockedReader.Object,
                mockedWriter.Object,
                teachers,
                students,
                mockedCommandFactory.Object);

            result.Start();

            mockedReader.Verify(x => x.ReadLine(), Times.Once());
        }

        [Test]
        public void Start_ShouldCallReadLineTwiceCreateACommandAndExecuteIt_WhenCommandIsPassed()
        {
            var teachers = new Dictionary<int, ITeacher>();
            var students = new Dictionary<int, IStudent>();
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Execute(It.IsAny<IList<string>>()))
                .Returns("EXECUTED!");

            var mockedWriter = new Mock<IWriter>();
            mockedWriter.Setup(x => x.WriteLine("EXECUTED!"));

            var mockedCommandFactory = new Mock<ICommandFactory>();
            mockedCommandFactory.Setup(x => x.CreateCommand(It.Is<string>(y => y == "CreateStudent")))
                                .Returns(new Mock<ICommand>().Object);

            var mockedReader = new Mock<IReader>();
            mockedReader.SetupSequence(x => x.ReadLine())
                .Returns("CreateStudent FirstName LastName 1")
                .Returns("End");

            var result = new SchoolSystemEngine(
                mockedReader.Object,
                mockedWriter.Object,
                teachers,
                students,
                mockedCommandFactory.Object);

            result.Start();

            mockedCommandFactory.Verify(x => x.CreateCommand(It.Is<string>(y => y == "CreateStudent")), Times.Once());
            mockedReader.Verify(x => x.ReadLine(), Times.Exactly(2));
            mockedWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once());
        }
    }
}
