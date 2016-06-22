namespace StudentsAndWorkers.Models
{
    using System;

    internal class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get { return grade; }
            set {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("The specified grade is invalid!");
                }
                grade = value; }
        }
    }
}
