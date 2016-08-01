namespace Dealership.Models
{
    using Dealership.Common;
    using Dealership.Contracts;

    public class Comment : IComment
    {
        private string _content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get { return this._content; }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinCommentLength, Constants.MaxCommentLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Content", Constants.MinCommentLength, Constants.MaxCommentLength));

                this._content = value;
            }
        }

        public string Author { get; set; }

        public override string ToString()
        {
            return string.Format("\n    ----------\n    {0}\n      User: {1}\n    ----------", 
                this.Content, this.Author);
        }
    }
}
