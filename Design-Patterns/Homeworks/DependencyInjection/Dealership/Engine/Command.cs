using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Dealership.Engine.Contracts;

namespace Dealership.Engine
{
    public class Command : ICommand
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private string _name;
        private List<string> _parameters;

        public Command(string input)
        {
            this.Parameters = new List<string>();
            this.TranslateInput(input);
        }

        public string Name
        {
            get
            {
                return this._name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {

                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this._name = value;
            }
        }

        public List<string> Parameters
        {
            get
            {
                return this._parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this._parameters = value;
            }
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);
            var indexOfOpenComment = input.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = input.IndexOf(CommentCloseSymbol);
            Regex regex = new Regex("{{.+(?=}})}}");

            if (indexOfFirstSeparator < 0)
            {
                this.Name = input;
                return;
            }

            this.Name = input.Substring(0, indexOfFirstSeparator);

            if (indexOfOpenComment >= 0)
            {
                this.Parameters.Add(input.Substring(indexOfOpenComment + CommentOpenSymbol.Length, indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment));
                input = regex.Replace(input, string.Empty);
            }

            this.Parameters.AddRange(input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
