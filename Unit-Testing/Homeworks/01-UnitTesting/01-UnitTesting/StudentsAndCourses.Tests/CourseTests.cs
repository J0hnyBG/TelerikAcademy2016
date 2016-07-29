namespace StudentsAndCourses.Tests
{
    using System;
    using MSTestExtensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Course_TryToAddExistingStudent_ShouldThrow()
        {
            School.ListOfStudents.Clear();
            var student = new Student("Petar", 12345u);
            var course = new Course();

            course.AddStudent(student);

            ThrowsAssert.Throws<InvalidOperationException>(() => course.AddStudent(student));
        }

        [TestMethod]
        public void Course_TryToAddNullStudent_ShouldThrow()
        {
            School.ListOfStudents.Clear();
            var course = new Course();

            ThrowsAssert.Throws<ArgumentNullException>(() => course.AddStudent(null));
        }

        [TestMethod]
        public void Course_AddStudentStudent_ShouldAdd()
        {
            School.ListOfStudents.Clear();
            var course = new Course();
            var student = new Student("Petar Petrov", 56487u);

            course.AddStudent(student);
            Assert.IsTrue(course.Students.Contains(student));
        }

        [TestMethod]
        public void Course_TryToRemoveNullStudent_ShouldThrow()
        {
            var course = new Course();

            ThrowsAssert.Throws<ArgumentException>(() => course.RemoveStudent(null));
        }

        [TestMethod]
        public void Course_RemoveStudent_ShouldRemoveStudent()
        {
            School.ListOfStudents.Clear();
            var student = new Student("Petar Petrov", 56487u);
            var course = new Course();
            course.AddStudent(student);

            course.RemoveStudent(student);

            Assert.IsFalse(course.Students.Contains(student));
        }

        [TestMethod]
        public void Student_TryToAddMoreThan30Students_ShouldThrow()
        {
            School.ListOfStudents.Clear();
            var course = new Course();

            for (uint i = 0; i < 31; i++)
            {
               course.AddStudent(new Student("Student " + i, 12000 + i));
            }

            ThrowsAssert.Throws<InvalidOperationException>(() => course.AddStudent(new Student("Petar", 21365u)));
        }

    }
}
