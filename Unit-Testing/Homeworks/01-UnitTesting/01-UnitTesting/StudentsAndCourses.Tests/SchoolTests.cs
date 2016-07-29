namespace StudentsAndCourses.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using StudentsAndCourses;
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void School_TryToAddNullStudent_ShouldThrow()
        {
            ThrowsAssert.Throws<InvalidOperationException>(() => School.AddStudent(null));
        }

        [TestMethod]
        public void School_TryToAddExistingStudent_ShouldThrow()
        {
            var student = new Student("Petar", 98765u);
            ThrowsAssert.Throws<InvalidOperationException>(() => School.AddStudent(student));
        }

        [TestMethod]
        public void Startup_JustForCoverage()
        {
            StudentsAndCourses.Startup.Main();
        }
    }
}
