namespace SchoolSystem.Core
{
    using System;

    using SchoolSystem.Contracts;

    /// <summary>
    /// Provides an implemetation of the IReader interface using the Console class.
    /// </summary>
    internal class ConsoleReader : IReader
    {
        /// <summary>
        /// Provides a method to read a line from the Console.
        /// </summary>
        /// <returns>A string read from the console.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}