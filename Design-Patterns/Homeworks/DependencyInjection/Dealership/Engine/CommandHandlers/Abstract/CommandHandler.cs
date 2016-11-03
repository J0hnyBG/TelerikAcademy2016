using System;

using Dealership.Engine.CommandHandlers.Contracts;
using Dealership.Engine.Contracts;

namespace Dealership.Engine.CommandHandlers.Abstract
{
    public abstract class CommandHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command!";

        private ICommandHandler next;

        private ICommandHandler Next
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

        public string HandleCommand(ICommand command, IDealershipEngine engine)
        {
            if (this.CanHandle(command))
            {
                return this.Handle(command, engine);
            }

            if (this.Next != null)
            {
                return this.Next.HandleCommand(command, engine);
            }

            return InvalidCommand;
        }

        public void SetNext(ICommandHandler nextHandler)
        {
            this.Next = nextHandler;
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command, IDealershipEngine engine);
    }
}
