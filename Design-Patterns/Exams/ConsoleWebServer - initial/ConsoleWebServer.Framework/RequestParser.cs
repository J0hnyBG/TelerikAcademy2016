using System;
using System.IO;

using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Exceptions;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework
{
    public class RequestParser : IRequestParser
    {
        private readonly IHttpRequestFactory _requestFactory;

        public RequestParser(IHttpRequestFactory requestFactory)
        {
            if (requestFactory == null)
            {
                throw new ArgumentNullException(nameof(requestFactory));
            }

            this._requestFactory = requestFactory;
        }

        public IHttpRequest Parse(string requestAsString)
        {
            var textReader = new StringReader(requestAsString);
            var firstLine = textReader.ReadLine();
            var requestObject = this.CreateRequest(firstLine);

            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                this.AddHeaderToRequest(requestObject, line);
            }

            return requestObject;
        }

        private IHttpRequest CreateRequest(string firstRequestLine)
        {
            var firstRequestLineParts = firstRequestLine.Split(' ');
            if (firstRequestLineParts.Length != 3)
            {
                throw new ParserException(
                    "Invalid format for the first request line. Expected format: [Method] [Uri] HTTP/[Version]");
            }

            var requestObject = this._requestFactory.GetHttpRequest(firstRequestLineParts[0],
                                                                    firstRequestLineParts[1],
                                                                    firstRequestLineParts[2]);

            return requestObject;
        }

        private void AddHeaderToRequest(IHttpMessage request, string headerLine)
        {
            var headerParts = headerLine.Split(new[] { ':' }, 2);
            var headerName = headerParts[0].Trim();
            var headerValue = headerParts.Length == 2 ? headerParts[1].Trim() : string.Empty;
            request.AddHeader(headerName, headerValue);
        }
    }
}
