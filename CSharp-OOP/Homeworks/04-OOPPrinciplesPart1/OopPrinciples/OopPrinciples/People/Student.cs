using System;

namespace OopPrinciples.People
{
    internal class Student : Person
    {
        private int classNumber;

        public Student(string comment, string name, int classNumber) : base(comment, name)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get { return classNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid class number!");
                }
                classNumber = value;
            }
        }
    }
}