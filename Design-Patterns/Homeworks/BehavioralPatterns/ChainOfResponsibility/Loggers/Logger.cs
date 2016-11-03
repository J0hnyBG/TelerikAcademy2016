namespace ChainOfResponsibility.Loggers
{
    using Enums;

    public abstract class Logger
    {
        protected readonly LogLevel LogLevel;

        private Logger _next;

        protected Logger(LogLevel level)
        {
            this.LogLevel = level;
        }

        public Logger SetNext(Logger nextlogger)
        {
            this._next = nextlogger;
            return nextlogger;
        }

        public void Message(string msg, LogLevel severity)
        {
            if (severity == this.LogLevel)
            {
                this.WriteMessage(msg);
            }
            else
            {
                this._next?.Message(msg, severity);
            }
        }

        protected abstract void WriteMessage(string msg);
    }
}
