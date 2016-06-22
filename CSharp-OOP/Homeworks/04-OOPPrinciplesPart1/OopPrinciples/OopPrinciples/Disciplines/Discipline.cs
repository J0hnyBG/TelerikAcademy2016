namespace OopPrinciples.Disciplines
{
    using Interfaces;

    class Discipline : ICommentable
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
            set { name = value; }
        }

        public int NumberOfLectures
        {
            get { return numberOfLectures; }
            set { numberOfLectures = value; }
        }

        public int NumberOfExercises
        {
            get { return numberOfExercises; }
            set { numberOfExercises = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
