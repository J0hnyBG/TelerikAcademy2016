namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Specifies an interface for a CommandFactory, containing methods for the creation of new Command objects.
    /// </summary>
    internal interface ICommandFactory
    {
        /// <summary>
        /// Returns a new Command object based on a command name.
        /// </summary>
        /// <param name="commandName">The Command name.</param>
        /// <returns>The initialized Command object</returns>
        ICommand CreateCommand(string commandName);
    }
}