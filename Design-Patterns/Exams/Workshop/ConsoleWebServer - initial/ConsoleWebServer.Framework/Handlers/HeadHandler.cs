using System.Net;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.Handlers
{
    public class HeadHandler : BaseHandler
    {
        public HeadHandler(IHttpResponseFactory responseFactory)
            : base(responseFactory)
        {
        }

        protected override bool CanHandle(IHttpRequest request)
        {
            return request.Method.ToLower() == "head";
        }

        protected override IHttpResponse Handle(IHttpRequest request)
        {
            return this.ResponseFactory.GetHttpResponse(request.ProtocolVersion.ToString(), HttpStatusCode.OK,
                                                        string.Empty);
        }
    }
}
