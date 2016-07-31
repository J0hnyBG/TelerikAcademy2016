namespace StudentsAndCourses.Tests
{
    using System;
    using MSTestExtensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudentsAndCourses.Common;
    using StudentsAndCourses.Models;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Ctor_CreateWithExistingNumber_ShouldThrowInvalidOperationExceptionWithCorrectMessage()
        {
            School.ListOfStudents.Clear();
            var student = new Student("Petar", 21365u);
            var ex = ThrowsAssert.Throws<InvalidOperationException>(() => new Student("Petar", 21365u));
            StringAssert.Contains(GlobalErrorMessages.CannodAddStudentWithSameNumberTwiceErrorMessage, ex.Message);
        }

        [TestMethod]
        public void Ctor_CreateWithNullName_ShouldThrowArgumentExceptionWithCorrectMessage()
        {
            var ex = ThrowsAssert.Throws<ArgumentException>(() => new Student(null, 23456));
            StringAssert.Contains(GlobalErrorMessages.StudentNameCannotBeEmpty, ex.Message);
        }

        [TestMethod]
        public void Ctor_CreateWithEmptyName_ShouldThrowArgumentExceptionWithCorrectMessage()
        {
            var ex = ThrowsAssert.Throws<ArgumentException>(() => new Student("", 23456));
            StringAssert.Contains(GlobalErrorMessages.StudentNameCannotBeEmpty, ex.Message);

        }
        [TestMethod]
        public void Ctor_CreateStudent_WithSmallerThanValidNumber_ShouldThrowArgumentExceptionWithCorrectMessage()
        {
            var ex = ThrowsAssert.Throws<ArgumentException>(() => new Student("Ivan", 9999));
            StringAssert.Contains(GlobalErrorMessages.StudentNumberNotInRange, ex.Message);
        }
        [TestMethod]
        public void Ctor_CreateWithLargerThanValidNumber_ShouldThrowArgumentExceptionWithCorrectMessage()
        {
            var ex = ThrowsAssert.Throws<ArgumentException>(() => new Student("Georgi", 100000));
            StringAssert.Contains(GlobalErrorMessages.StudentNumberNotInRange, ex.Message);
        }

        [TestMethod]
        public void Ctor_CreateWithValidNumber_ShouldCreateStudentCorrectly()
        {
            School.ListOfStudents.Clear();
            var studentNumber = 23455u;
            var student = new Student("Petrov", studentNumber);

            Assert.AreEqual(studentNumber, student.Number);
        }
        [TestMethod]
        public void Ctor_CreateWithValidName_ShouldCreateStudent()
        {
            School.ListOfStudents.Clear();
            var studentName = "Ivan";
            var student = new Student(studentName, 65432);

            Assert.AreEqual(studentName, student.Name);
        }
    }
}
