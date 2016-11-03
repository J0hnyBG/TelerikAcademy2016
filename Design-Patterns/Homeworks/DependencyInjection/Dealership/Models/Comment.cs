using System.Text;

using Dealership.Common;
using Dealership.Common.Contracts;
using Dealership.Contracts;
using Dealership.Models.Abstract;

namespace Dealership.Models
{
    public class Comment : Validatable, IComment
    {
        private const string CommentHeader = "    ----------";
        private const string ContentProperty = "Content";
        private const string CommentIndentation = "    ";
        private const string AuthorHeader = "      User: ";

        private string _content;

        public Comment(string content, IValidatorProvider validator)
            : base(validator)
        {
            this.Content = content;
        }

        public string Content
        {
            get
            {
                return this._content; 
            }

            private set
            {
                this.Validator.ValidateNull(value, string.Format(Constants.PropertyCannotBeNull, ContentProperty));
                this.Validator.ValidateIntRange(value.Length, Constants.MinCommentLength,
                                                Constants.MaxCommentLength,
                                                string.Format(Constants.StringMustBeBetweenMinAndMax, ContentProperty,
                                                              Constants.MinCommentLength, Constants.MaxCommentLength));

                this._content = value;
            }
        }

        public string Author { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(string.Format("{0}", CommentHeader));
            builder.AppendLine(CommentIndentation + this.Content);
            builder.AppendLine(AuthorHeader + this.Author);
            builder.Append(string.Format("{0}", CommentHeader));

            return builder.ToString();
        }
    }
}
