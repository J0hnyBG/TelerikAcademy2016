namespace StudentsAndCourses.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StudentsAndCourses.Common;

    public static class School
    {
        static School()
        {
            School.ListOfStudents = new List<Student>();
        }

        public static ICollection<Student> ListOfStudents { get; private set; }

        public static void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new InvalidOperationException(GlobalErrorMessages.CannotAddNullStudentErrorMessage);
            }
            if (School.ListOfStudents.Contains(student))
            {
                throw new InvalidOperationException(GlobalErrorMessages.CannodAddSameStudentTwiceErrorMessage);
            }
            if (ListOfStudents.Count(s => s.Number == student.Number) != 0)
            {
                throw new InvalidOperationException(GlobalErrorMessages.CannodAddStudentWithSameNumberTwiceErrorMessage);
            }
            School.ListOfStudents.Add(student);
        }

    }
}