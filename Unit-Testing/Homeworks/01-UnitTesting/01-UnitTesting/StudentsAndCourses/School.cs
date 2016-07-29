namespace StudentsAndCourses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

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
                throw new InvalidOperationException("Cannot add null student");
            }
            if (School.ListOfStudents.Contains(student))
            {
                throw new InvalidOperationException("Cannot add same student twice!");
            }
            if (ListOfStudents.Count(s => s.Number == student.Number) != 0)
            {
                throw new InvalidOperationException("Cannot add a student with the same number twice!");
            }
            School.ListOfStudents.Add(student);
        }

    }
}