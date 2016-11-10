using System;
using System.IO;
using System.Net;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.Handlers
{
    public class StaticFileHandler : BaseHandler
    {
        public StaticFileHandler(IHttpResponseFactory responseFactory)
            : base(responseFactory)
        {
        }

        protected override bool CanHandle(IHttpRequest request)
        {
            return request.Uri.LastIndexOf(".", StringComparison.Ordinal)
                   > request.Uri.LastIndexOf("/", StringComparison.Ordinal);
        }

        protected override IHttpResponse Handle(IHttpRequest request)
        {
            var filePath = Environment.CurrentDirectory + "/" + request.Uri;
            if (!File.Exists(filePath))
            {
                return this.ResponseFactory.GetHttpResponse(request.ProtocolVersion.ToString(),
                                                            HttpStatusCode.NotFound,
                                                            "File not found!");
            }

            var fileContents = File.ReadAllText(filePath);
            var response = this.ResponseFactory.GetHttpResponse(request.ProtocolVersion.ToString(),
                                                                HttpStatusCode.OK,
                                                                fileContents);
            return response;
        }
    }
}
