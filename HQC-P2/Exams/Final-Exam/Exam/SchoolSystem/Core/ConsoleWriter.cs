namespace SchoolSystem.Core
{
    using System;

    using SchoolSystem.Contracts;

    /// <summary>
    /// Provides an implementation of the IWriter interface using the Console class.
    /// </summary>
    internal class ConsoleWriter : IWriter
    {
        /// <summary>
        /// Writes a string to the Console with no new line at the end.
        /// </summary>
        /// <param name="message">The string to be written.</param>
        public void Write(string message)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Console.Write(message);
        }

        /// <summary>
        /// Writes a string to the Console with a new line at the end.
        /// </summary>
        /// <param name="message">The string to be written.</param>
        public void WriteLine(string message)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Console.WriteLine(message);
        }
    }
}