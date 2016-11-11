using System;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Application.WebServer
{
    public class ConsoleInputOutputProvider : IConsoleInputOutputProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void WriteLine(IHttpResponse response)
        {
            Console.WriteLine(response);
        }

        public void ResetColor()
        {
            Console.ResetColor();
        }
    }
}
