namespace SchoolSystem.Models
{
    using System;

    using Contracts;

    internal class Mark : IMark
    {
        private const string InvalidValueErrorMesage = "Mark value must be between 2 and 6!";
        private Subject subject;
        private float value;

        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public Subject Subject
        {
            get { return this.subject; }
            private set { this.subject = value; }
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Value), InvalidValueErrorMesage);
                }

                this.value = value;
            }
        }
    }
}
