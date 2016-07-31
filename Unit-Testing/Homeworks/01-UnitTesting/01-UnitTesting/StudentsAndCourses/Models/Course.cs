namespace StudentsAndCourses.Models
{
    using System;
    using System.Collections.Generic;
    using StudentsAndCourses.Common;

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
            if (this.Students.Count > Constants.MaxStudentsPerCourse)
            {
                throw new InvalidOperationException(GlobalErrorMessages.StudentsCannotBeMoreThan30ErrorMessage);
            }
            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException(GlobalErrorMessages.CannodAddSameStudentTwiceErrorMessage);
            }
            this.Students.Add(student);
        }

        public bool RemoveStudent(Student st)
        {
            if ( st == null )
            {
                throw new ArgumentException(GlobalErrorMessages.CannotRemoveNullStudentErrorMessage);
            }
            return this.Students.Remove(st);
        }
    }
}