using System;

namespace StudentsAndWorkers.Models
{
    internal abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if ( string.IsNullOrEmpty(value) )
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                lastName = value;
            }
        }

    }
}
