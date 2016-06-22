namespace OopPrinciples.People
{
    using Interfaces;

    internal class Person :ICommentable
    {
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
