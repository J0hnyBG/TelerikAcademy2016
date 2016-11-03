namespace ChainOfResponsibility.Loggers
{
    using System;

    using Enums;

    public class EmailLogger : Logger
    {
        public EmailLogger(LogLevel level)
            : base(level)
        {
        }

        protected override void WriteMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sending mass email: " + msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}