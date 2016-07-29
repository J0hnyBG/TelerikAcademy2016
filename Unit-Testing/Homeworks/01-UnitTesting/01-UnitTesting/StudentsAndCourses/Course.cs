namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public Course()
        {
            this.Students = new List<Student>();
        }

        public ICollection<Student> Students { get; private set; }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            if (this.Students.Count > 30)
            {
                throw new InvalidOperationException("Students in a course can not be more than 30!");
            }
            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException("Cannot add the same student twice!");
            }
            this.Students.Add(student);
        }

        public bool RemoveStudent(Student st)
        {
            if ( st == null )
            {
                throw new ArgumentException("Cannot remove null student!");
            }
            return this.Students.Remove(st);
        }
    }
}