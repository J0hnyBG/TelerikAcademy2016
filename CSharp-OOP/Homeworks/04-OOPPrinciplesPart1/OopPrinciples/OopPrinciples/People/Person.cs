namespace OopPrinciples.People
{
    using Interfaces;

    internal class Person :ICommentable
    {
        private string comment;
        private string name;

        public Person(string name, string comment = null)
        {
            this.Comment = comment;
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
