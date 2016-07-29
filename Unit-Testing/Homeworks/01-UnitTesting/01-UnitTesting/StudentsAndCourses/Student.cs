namespace StudentsAndCourses
{
    using System;

    public class Student
    {
        private string _name;
        private uint _number;

        public Student(string name, uint number)
        {
            this.Name = name;
            this.Number = number;
            School.AddStudent(this);
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student _name cannot be empty!");
                }
                this._name = value;
            }
        }

        public uint Number
        {
            get { return this._number; }
            private set
            {
                if (value > 99999 || value < 10000)
                {
                    throw new ArgumentException("Student _number must be between 10000 and 99999");
                }
                this._number = value;
            }
        }
    }
}