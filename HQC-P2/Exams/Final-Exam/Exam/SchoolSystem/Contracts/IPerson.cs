namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Provides an interface for a Person data model.
    /// </summary>
    internal interface IPerson
    {
        /// <summary>
        /// Gets the student's first name.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Gets the student's last name.
        /// </summary>
        string LastName { get; }
    }
}
