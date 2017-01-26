using System.Collections.Generic;

namespace _03_Students.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new List<string>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string University { get; set; }
        public IList<string> Courses { get; set; }

    }
}