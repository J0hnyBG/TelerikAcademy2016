using System;
using System.Net;

using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Handlers;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework
{
    public class ResponseProvider : IResponseProvider
    {
        private readonly IRequestParser _requestParser;
        private readonly IHttpResponseFactory _responseFactory;
        private readonly IHandler _headHandler;

        public ResponseProvider(IRequestParser requestParser,
                                IHttpResponseFactory responseFactory,
                                IHandler headHandler)
        {
            if (requestParser == null)
            {
                throw new ArgumentNullException(nameof(requestParser));
            }

            if (responseFactory == null)
            {
                throw new ArgumentNullException(nameof(responseFactory));
            }

            if (headHandler == null)
            {
                throw new ArgumentNullException(nameof(headHandler));
            }

            this._requestParser = requestParser;
            this._responseFactory = responseFactory;
            this._headHandler = headHandler;
        }

        public IHttpResponse GetResponse(string requestAsString)
        {
            IHttpRequest request;
            try
            {
                request = this._requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return this._responseFactory.GetHttpResponse(new Version(1, 1).ToString(),
                                                             HttpStatusCode.BadRequest,
                                                             ex.Message);
            }

            var response = this._headHandler.HandleRequest(request);

            return response;
        }
    }
}
