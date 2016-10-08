namespace SchoolSystem.Contracts
{
    using Models;

    /// <summary>
    /// Interface for a student Mark data model.
    /// </summary>
    internal interface IMark
    {
        /// <summary>
        /// Gets the IMark's subject.
        /// </summary>
        Subject Subject { get; }

        /// <summary>
        /// Gets the IMark's value.
        /// </summary>
        float Value { get; }
    }
}
