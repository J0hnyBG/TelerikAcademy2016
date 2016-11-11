using System;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CreationHandlers
{
    public abstract class CommandCreationHandler : IHandler
    {
        private ICommandFactory commandFactory;
        private IHandler next;

        protected CommandCreationHandler(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public IHandler Next
        {
            get { return this.next; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Next));
                }

                this.next = value;
            }
        }

        protected ICommandFactory CommandFactory
        {
            get { return this.commandFactory; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.CommandFactory));
                }

                this.commandFactory = value;
            }
        }

        public ICommand HandleCreation(string commandName)
        {
            if (this.CanHandle(commandName))
            {
                return this.Handle();
            }

            if (this.Next != null)
            {
                return this.Next.HandleCreation(commandName);
            }

            throw new ArgumentException("The passed command is not found!");
        }

        protected abstract bool CanHandle(string commandName);

        protected abstract ICommand Handle();
    }
}
