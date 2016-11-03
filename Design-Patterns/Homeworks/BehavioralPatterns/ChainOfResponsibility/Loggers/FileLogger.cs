namespace ChainOfResponsibility.Loggers
{
    using System;

    using Enums;

    internal class FileLogger : Logger
    {
        public FileLogger(LogLevel level)
            : base(level)
        {
        }

        protected override void WriteMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Writing to log file: " + msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}