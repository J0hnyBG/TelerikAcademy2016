namespace SchoolSystem.Core.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    /// <summary>
    /// Provides method for the creation of different types of ICommand objects.
    /// </summary>
    internal class CommandFactory : ICommandFactory
    {
        private const string CommandNotFoundErrorMessage = "The passed command is not found!";

        /// <summary>
        /// Creates a different type of ICommand object, depending on the commandName parameter.
        /// </summary>
        /// <param name="commandName">The name of the command to be created.</param>
        /// <returns>The initialized ICommand object.</returns>
        public ICommand CreateCommand(string commandName)
        {
            if (string.IsNullOrEmpty(commandName))
            {
                throw new ArgumentNullException(nameof(commandName), "Invalid command!");
            }

            var assembly = this.GetType().GetTypeInfo().Assembly;
            var typeInfo = assembly.DefinedTypes
                                   .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                                   .FirstOrDefault(type => type.Name.ToLower().Contains(commandName.ToLower()));
            if (typeInfo == null)
            {
                throw new ArgumentNullException(nameof(typeInfo), CommandNotFoundErrorMessage);
            }

            var command = Activator.CreateInstance(typeInfo) as ICommand;

            return command;
        }
    }
}
