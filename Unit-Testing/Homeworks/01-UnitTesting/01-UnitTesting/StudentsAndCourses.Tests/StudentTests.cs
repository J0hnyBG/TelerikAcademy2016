namespace StudentsAndCourses.Tests
{
    using System;
    using MSTestExtensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Student_TryToCreateExistingStudent_ShouldThrow()
        {
            School.ListOfStudents.Clear();
            var student = new Student("Petar", 21365u);
            ThrowsAssert.Throws<InvalidOperationException>(() => new Student("Petar", 21365u));
        }

        [TestMethod]
        public void Student_TryToCreateWithNullName_ShouldThrow()
        {
            ThrowsAssert.Throws<ArgumentException>(() => new Student(null, 23456));
        }

        [TestMethod]
        public void Student_TryToCreateWithEmptyName_ShouldThrow()
        {
            ThrowsAssert.Throws<ArgumentException>(() => new Student("", 23456));
        }
        [TestMethod]
        public void Student_TryToCreateWithSmallerThanValidNumber_ShouldThrow()
        {
            ThrowsAssert.Throws<ArgumentException>(() => new Student("Ivan", 9999));
        }
        [TestMethod]
        public void Student_TryToCreateWithLargerThanValidNumber_ShouldThrow()
        {
            ThrowsAssert.Throws<ArgumentException>(() => new Student("Georgi", 100000));
        }

        [TestMethod]
        public void Student_CreateWithValidNumber_ShouldCreateStudent()
        {
            School.ListOfStudents.Clear();
            var studentNumber = 23455u;
            var student = new Student("Petrov", studentNumber);

            Assert.AreEqual(studentNumber, student.Number);
        }
        [TestMethod]
        public void Student_CreateWithValidName_ShouldCreateStudent()
        {
            var studentName = "Ivan";
            var student = new Student(studentName, 65432);

            Assert.AreEqual(studentName, student.Name);
        }
    }
}
