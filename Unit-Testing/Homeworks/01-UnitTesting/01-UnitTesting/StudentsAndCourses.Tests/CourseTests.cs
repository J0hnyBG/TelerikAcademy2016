namespace StudentsAndCourses.Tests
{
    using System;
    using MSTestExtensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsAndCourses.Models;
    using StudentsAndCourses.Common;

    [TestClass]
    public class CourseTests
    {

        [TestMethod]
        public void AddStudent_WhenStudentAlreadyExists_ShouldThrowInvalidOperationExceptionWithCorrectMessage()
        {
            School.ListOfStudents.Clear();
            var student = new Student("Petar", 12345u);
            var course = new Course();

            course.AddStudent(student);

            var ex = ThrowsAssert.Throws<InvalidOperationException>(() => course.AddStudent(student));
            StringAssert.Contains(GlobalErrorMessages.CannodAddSameStudentTwiceErrorMessage, ex.Message);
        }

        [TestMethod]
        public void AddStudent_WhenStudentIsNull_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            School.ListOfStudents.Clear();
            var course = new Course();

            var ex = ThrowsAssert.Throws<ArgumentNullException>(() => course.AddStudent(null));
            StringAssert.Contains(ex.Message, "student");

        }

        [TestMethod]
        public void AddStudent_ShouldAddStudentToListOfStudentsCorrectly()
        {
            School.ListOfStudents.Clear();
            var course = new Course();
            var student = new Student("Petar Petrov", 56487u);

            course.AddStudent(student);
            Assert.IsTrue(course.Students.Contains(student));
        }

        [TestMethod]
        public void RemoveStudent_WhenStudentIsNull_ShouldThrowArgumentExceptionWithCorrectMessage()
        {
            var course = new Course();

            var ex = ThrowsAssert.Throws<ArgumentException>(() => course.RemoveStudent(null));
            StringAssert.Contains(GlobalErrorMessages.CannotRemoveNullStudentErrorMessage, ex.Message);
        }

        [TestMethod]
        public void RemoveStudent_ShouldRemoveStudent()
        {
            School.ListOfStudents.Clear();
            var student = new Student("Petar Petrov", 56487u);
            var course = new Course();
            course.AddStudent(student);

            course.RemoveStudent(student);

            Assert.IsFalse(course.Students.Contains(student));
        }

        [TestMethod]
        public void AddMoreThan30Students_ShouldThrowInvalidOperationExceptionWithCorrectMessage()
        {
            School.ListOfStudents.Clear();
            var course = new Course();

            for (uint i = 0; i < 31; i++)
            {
               course.AddStudent(new Student("Student " + i, 12000 + i));
            }

            var ex = ThrowsAssert.Throws<InvalidOperationException>(() => course.AddStudent(new Student("Petar", 21365u)));
            StringAssert.Contains(GlobalErrorMessages.StudentsCannotBeMoreThan30ErrorMessage, ex.Message);

        }

    }
}
