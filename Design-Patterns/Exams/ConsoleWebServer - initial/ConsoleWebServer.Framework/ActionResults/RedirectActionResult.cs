using System.Collections.Generic;
using System.Net;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class RedirectActionResult : BaseActionResult
    {
        public RedirectActionResult(IHttpRequest request, string location, IHttpResponseFactory httpResponseFactory)
            : base(request, httpResponseFactory)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Location", location));
        }

        protected override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.Redirect;
        }
    }
}
