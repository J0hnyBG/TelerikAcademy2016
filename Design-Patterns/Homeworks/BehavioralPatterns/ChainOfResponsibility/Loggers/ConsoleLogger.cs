namespace ChainOfResponsibility.Loggers
{
    using System;

    using Enums;

    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel level)
            : base(level)
        {
        }

        protected override void WriteMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Writing to console: " + msg);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}