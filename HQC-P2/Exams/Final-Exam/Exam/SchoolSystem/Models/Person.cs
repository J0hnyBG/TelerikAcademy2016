namespace SchoolSystem.Models
{
    using System;

    using Const;

    using Contracts;

    using Validation;

    internal abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateName(value, "First name");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidateName(value, "Last name");

                this.lastName = value;
            }
        }

        private void ValidateName(string name, string errorMsgContent)
        {
            if (!Validator.IsStringLengthValid(name, Constants.MinNameLength, Constants.MaxNameLength))
            {
                throw new ArgumentException(string.Format(
                                                          Constants.InvalidLengthErrorMessage,
                                                          errorMsgContent,
                                                          Constants.MinNameLength,
                                                          Constants.MaxNameLength));
            }

            if (!Validator.AreAllStringCharsLatin(name))
            {
                throw new ArgumentException(string.Format(
                                                          Constants.StringContainsInvalidCharsErrorMessage,
                                                          errorMsgContent));
            }
        }
    }
}
