namespace OopPrinciples.Disciplines
{
    using System;
    using Interfaces;

    internal class Discipline : ICommentable
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        private string comment;

        public Discipline(string name, int numberOfLectures, int numberOfExercises, string comment = null)
        {
            this.name = name;
            this.numberOfLectures = numberOfLectures;
            this.numberOfExercises = numberOfExercises;
            this.comment = comment;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (AssertNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                name = value;
            }
        }

        public int NumberOfLectures
        {
            get { return numberOfLectures; }
            set
            {
                if (AssertLessThanZero(value))
                {
                    throw new ArgumentException("Number of lectures cannot be negative!");

                }
                numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get { return numberOfExercises; }
            set
            {
                if ( AssertLessThanZero(value) )
                {
                    throw new ArgumentException("Number of exercises cannot be negative!");

                }
                numberOfExercises = value;
            }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private static bool AssertNullOrEmpty(string s)
        {
            return string.IsNullOrEmpty(s);
        }

        private static bool AssertLessThanZero(int i)
        {
            return i < 0;
        }
    }
}
