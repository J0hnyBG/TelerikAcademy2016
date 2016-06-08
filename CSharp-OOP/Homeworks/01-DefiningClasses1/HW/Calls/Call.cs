namespace HW.Calls
{
    using System;

    internal class Call
    {
        //Problem 8 - Calls Class
        private DateTime dateTime;
        private int durationInSeconds;
        private string dialedNumber;

        public Call(int durationInSeconds, DateTime dateTime, string dialedNumber)
        {
            DurationInSeconds = durationInSeconds;
            DateTime = dateTime;
            DialedNumber = dialedNumber;
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (value > DateTime.Now || value < DateTime.Now.AddYears(-100))
                {
                    throw new ArgumentException("The supplied call date is invalid!");
                }
                dateTime = value;
            }
        }

        public int DurationInSeconds
        {
            get { return durationInSeconds; }
            set
            {
                if (durationInSeconds < 0)
                {
                    throw new ArgumentException("The supplied call duration is invalid!");
                }
                durationInSeconds = value;
            }
        }

        public string DialedNumber
        {
            get { return dialedNumber; }
            set
            {
                if (value.Length < 6)
                {
                    throw new ArgumentException("The supplied phone number is invalid!");
                }
                dialedNumber = value;
            }
        }
    }
}