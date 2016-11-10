using System;

namespace ConsoleWebServer.Framework.Exceptions
{
    public class ParserException : Exception
    {
        public ParserException(string message)
            : base(message)
        {
        }
    }
}
