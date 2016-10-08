namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Specifies an interface for an abstract reader.
    /// </summary>
   internal interface IReader
    {
        /// <summary>
        /// Reads a line of text.
        /// </summary>
        /// <returns>The line of text as a string.</returns>
        string ReadLine();
    }
}
