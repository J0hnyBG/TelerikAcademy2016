namespace SchoolSystem.Models
{
    using System;

    using Const;

    using Contracts;

    internal class Teacher : Person, ITeacher
    {
        private Subject subject;

        internal Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                if (value < Subject.Bulgarian || value > Subject.Programming)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Subject), string.Format(Constants.OutOfRangeErrorMessage, "Subject", "1", "4"));
                }

                this.subject = value;
            }
        }

        public void AddMark(IStudent student, float value)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), string.Format(Constants.NullObjectErrorMessage, "Student"));
            }

            var mark = new Mark(this.Subject, value);
            student.AddMark(mark);
        }
    }
}
