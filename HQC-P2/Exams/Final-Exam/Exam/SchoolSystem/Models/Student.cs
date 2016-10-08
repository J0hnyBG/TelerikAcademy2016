namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Const;

    using Contracts;

    internal class Student : Person, IStudent
    {
        private const int MaxMarksCount = 20;
        private const string TooManyStudentMarksErrorMessage = "Student marks cannot be more than {0}!";
        private const string NoMarksMessage = "This student has no marks.";

        private Grade grade;
        private IList<IMark> marks;

        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if (value < Grade.First || value > Grade.Twelveth)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Grade), string.Format(Constants.OutOfRangeErrorMessage, "Grade", "1", "12"));
                }

                this.grade = value;
            }
        }

        public IList<IMark> Marks
        {
            get { return this.marks; }
            private set { this.marks = value; }
        }

        public string ListMarks()
        {
            if (this.Marks.Count == 0)
            {
                return NoMarksMessage;
            }

            var formattedMarksWithSubject = this.marks.Select(mark => $"{mark.Subject} => {mark.Value}").ToList();
            return "The student has these marks:\n" + string.Join("\n", formattedMarksWithSubject);
        }

        public void AddMark(IMark mark)
        {
            if (mark == null)
            {
                throw new ArgumentNullException(nameof(mark), string.Format(Constants.NullObjectErrorMessage, "Student"));
            }

            if (this.Marks.Count >= MaxMarksCount)
            {
                throw new InvalidOperationException(string.Format(TooManyStudentMarksErrorMessage, MaxMarksCount));
            }

            this.Marks.Add(mark);
        }
    }
}
