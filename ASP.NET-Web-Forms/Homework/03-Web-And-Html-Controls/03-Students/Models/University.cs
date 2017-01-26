using System.Collections;
using System.Collections.Generic;

namespace _03_Students.Models
{
    public class University : IEnumerable<Student>
    {
        public University()
        {
            this.Students = new List<Student>();
        }

        public IList<Student> Students { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return this.Students.GetEnumerator();
        }
    }
}