using System;

namespace ConsoleWebServer.Framework.Exceptions
{
    public class HttpNotFoundException : Exception
    {
        public HttpNotFoundException(string message)
            : base(message)
        {
        }
    }
}
