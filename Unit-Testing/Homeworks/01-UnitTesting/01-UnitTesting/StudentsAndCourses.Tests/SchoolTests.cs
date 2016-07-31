namespace StudentsAndCourses.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using StudentsAndCourses.Common;
    using StudentsAndCourses.Models;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void AddStudent_WhenStudentIsNull_ShouldThrowInvalidOperationExceptionWithCorrectMessage()
        {
            var ex = ThrowsAssert.Throws<InvalidOperationException>(() => School.AddStudent(null));
            StringAssert.Contains(GlobalErrorMessages.CannotAddNullStudentErrorMessage, ex.Message);
        }

        [TestMethod]
        public void AddStudent_WhenStudentAlreadyExists_ShouldThrowInvalidOperationExceptionWithCorrectMessage()
        {
            var student = new Student("Petar", 98765u);
            var ex = ThrowsAssert.Throws<InvalidOperationException>(() => School.AddStudent(student));
            StringAssert.Contains(GlobalErrorMessages.CannodAddSameStudentTwiceErrorMessage, ex.Message);
        }

        [TestMethod]
        public void Startup_JustForCoverage()
        {
            StudentsAndCourses.Startup.Main();
        }
    }
}