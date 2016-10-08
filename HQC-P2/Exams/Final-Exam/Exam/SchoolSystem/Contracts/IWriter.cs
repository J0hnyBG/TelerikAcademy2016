namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Specifies an interface for an abstract writer.
    /// </summary>
    internal interface IWriter
    {
        /// <summary>
        /// Writes a string with no new line at the end.
        /// </summary>
        /// <param name="message">The string to be written.</param>
        void Write(string message);

        /// <summary>
        /// Writes a string with a new line at the end.
        /// </summary>
        /// <param name="message">The string to be written.</param>
        void WriteLine(string message);
    }
}
