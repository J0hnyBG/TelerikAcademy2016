namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Specifies an interface for a SchoolSystemEngine command.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Executes an ICommand given a list of parameters.
        /// </summary>
        /// <param name="parameters">The specified list of parameters.</param>
        /// <returns>The result of the command execution.</returns>
        string Execute(IList<string> parameters);
    }
}
