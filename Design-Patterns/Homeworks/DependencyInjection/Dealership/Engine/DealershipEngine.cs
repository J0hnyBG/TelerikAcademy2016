using System;
using System.Collections.Generic;
using System.Text;

using Dealership.Contracts;
using Dealership.Engine.CommandHandlers.Contracts;
using Dealership.Engine.ConsoleProviders;
using Dealership.Engine.Contracts;
using Dealership.Factories;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IDealershipEngine
    {
        private const string UserNotLogged = "You are not logged! Please login first!";

        private readonly IDealershipFactory _factory;
        private ICollection<IUser> _users;
        private IUser _loggedUser;
        private IConsoleInputOutputProvider _console;
        private readonly ICommandHandler _commandHandler;

        public DealershipEngine(IDealershipFactory factory,
                                IConsoleInputOutputProvider consoleInputOutputProvider,
                                ICommandHandler commandHandler)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (consoleInputOutputProvider == null)
            {
                throw new ArgumentNullException(nameof(consoleInputOutputProvider));
            }

            if (commandHandler == null)
            {
                throw new ArgumentNullException(nameof(commandHandler));
            }

            this._factory = factory;
            this._commandHandler = commandHandler;
            this._console = consoleInputOutputProvider;
            this._users = new List<IUser>();
            this._loggedUser = null;
        }

        public IDealershipFactory Factory
        {
            get { return this._factory; }
        }

        public ICollection<IUser> Users
        {
            get { return this._users; }
        }

        public IUser LoggedUser
        {
            get { return this._loggedUser; }

            private set { this._loggedUser = value; }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            this._users = new List<IUser>();
            this._loggedUser = null;
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }

        public void LoginUser(IUser user)
        {
            this.LoggedUser = user;
        }

        private IEnumerable<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this._console.ReadInput();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = this.Factory.GetCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this._console.ReadInput();
            }

            return commands;
        }

        private IEnumerable<string> ProcessCommands(IEnumerable<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IEnumerable<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this._console.WriteOutput(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != "RegisterUser" && command.Name != "Login" && this._loggedUser == null)
            {
                return UserNotLogged;
            }

            return this._commandHandler.HandleCommand(command, this);
        }
    }
}
