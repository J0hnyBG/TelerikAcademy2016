namespace CreationalPatterns
{
    using System;
    using System.IO;

    /// <summary>
    /// A class providing methods for the management of a single log file.
    /// </summary>
    /// <remarks>
    /// The logger is a suitible candidate for a Singleton pattern because it represents a single shared resource that has to be managed.
    /// </remarks>
    public class Logger
    {
        private const string FileLocation = "..\\..\\..\\log.txt";
        private static readonly Lazy<Logger> Lazy = new Lazy<Logger>(() => new Logger());

        private Logger()
        {
            
        }

        public void Log(string toLog)
        {
            //Write to log file. 
        }

        public static Logger Instance
        {
            get { return Lazy.Value; }
        }
    }
}
