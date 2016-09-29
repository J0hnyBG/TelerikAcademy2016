namespace StringExtensions
{
    using System;

    using log4net;
    using log4net.Config;

    public class Startup
    {
        private static ILog log = LogManager.GetLogger("Applogger");

        public static void Main()
        {
            BasicConfigurator.Configure();

            log.Info("Entering application.");
            Console.WriteLine();
            log.Info("Exiting application.");
        }
    }
}
