using System;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Application.WebServer
{
    public interface IConsoleInputOutputProvider
    {
        string ReadLine();

        void SetForegroundColor(ConsoleColor color);

        void WriteLine(IHttpResponse response);

        void ResetColor();
    }
}
