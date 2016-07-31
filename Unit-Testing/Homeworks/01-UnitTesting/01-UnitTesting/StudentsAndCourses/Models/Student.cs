namespace StudentsAndCourses.Models
{
    using System;
    using StudentsAndCourses.Common;

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
                    throw new ArgumentException(GlobalErrorMessages.StudentNameCannotBeEmpty);
                }
                this._name = value;
            }
        }

        public uint Number
        {
            get { return this._number; }
            private set
            {
                if (value > Constants.MaxStudentNumber || value < Constants.MinStudentNumber)
                {
                    throw new ArgumentException(GlobalErrorMessages.StudentNumberNotInRange);
                }
                this._number = value;
            }
        }
    }
}