using System;
using System.Collections.Generic;
using System.Net;

using ConsoleWebServer.Framework.HttpMessages;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.ActionResults
{
    public abstract class BaseActionResult : IActionResult
    {
        private readonly IHttpResponseFactory _httpResponseFactory;
        private readonly IHttpRequest _request;
        private readonly IList<KeyValuePair<string, string>> _responseHeaders;

        protected BaseActionResult(IHttpRequest request, IHttpResponseFactory httpResponseFactory)
        {
            if (httpResponseFactory == null)
            {
                throw new ArgumentNullException(nameof(httpResponseFactory));
            }

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            this._request = request;
            this._httpResponseFactory = httpResponseFactory;
            this._responseHeaders = new List<KeyValuePair<string, string>>();
        }

        protected IList<KeyValuePair<string, string>> ResponseHeaders
        {
            get { return this._responseHeaders; }
        }

        private IHttpRequest Request
        {
            get { return this._request; }
        }

        public IHttpResponse GetResponse()
        {
            var version = this.Request.ProtocolVersion.ToString();
            var response = this._httpResponseFactory.GetHttpResponse(version,
                                                                     this.GetStatusCode(),
                                                                     this.GetContent(),
                                                                     this.GetContentType());
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }

        protected virtual string GetContent()
        {
            return string.Empty;
        }

        protected virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        protected virtual string GetContentType()
        {
            return HttpResponse.DefaultContentType;
        }
    }
}
