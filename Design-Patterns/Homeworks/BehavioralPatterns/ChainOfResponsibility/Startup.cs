namespace ChainOfResponsibility
{
    using Loggers;
    using Loggers.Enums;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var consoleLogger = new ConsoleLogger(LogLevel.Info);
            var fileLogger = new FileLogger(LogLevel.Warning);
            var emailLogger = new EmailLogger(LogLevel.CriticalError);

            consoleLogger.SetNext(fileLogger)
                         .SetNext(emailLogger);

            consoleLogger.Message("Info: New order recieved.", LogLevel.Info);
            consoleLogger.Message("Warning: customer address is invalid.", LogLevel.Warning);
            consoleLogger.Message("Critical error: Someone dropped the prod database!", LogLevel.CriticalError);
        }
    }
}
