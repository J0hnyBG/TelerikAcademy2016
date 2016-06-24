namespace OopPrinciples.People
{
    using System;
    using System.Collections.Generic;
    internal class Student : Person
    {
        internal static List<int> uniqueClassNumbers = new List<int>();
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
                if (Student.uniqueClassNumbers.Contains(value))
                {
                    throw new ArgumentException("This class number already exists!");
                }
                Student.uniqueClassNumbers.Add(value);
                this.classNumber = value;
            }
        }
    }
}