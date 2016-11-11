using System;
using System.Text;

using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Application.WebServer
{
    public class WebServerConsole : IWebServerConsole
    {
        private readonly IResponseProvider _responseProvider;
        private readonly IConsoleInputOutputProvider _inputOutputProvider;

        public WebServerConsole(IResponseProvider responseProvider, IConsoleInputOutputProvider inputOutputProvider)
        {
            if (responseProvider == null)
            {
                throw new ArgumentNullException(nameof(responseProvider));
            }

            if (inputOutputProvider == null)
            {
                throw new ArgumentNullException(nameof(inputOutputProvider));
            }

            this._responseProvider = responseProvider;
            this._inputOutputProvider = inputOutputProvider;
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = this._inputOutputProvider.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this._responseProvider.GetResponse(requestBuilder.ToString());
                    this._inputOutputProvider.SetForegroundColor(ConsoleColor.DarkGray);
                    this._inputOutputProvider.WriteLine(response);
                    this._inputOutputProvider.ResetColor();
                    requestBuilder.Clear();
                    continue;
                }

                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}
