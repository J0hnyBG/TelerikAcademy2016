using System.Net;

namespace ConsoleWebServer.Framework.HttpMessages.Contracts
{
    public interface IHttpResponseFactory
    {
        IHttpResponse GetHttpResponse(string httpVersion,
                                      HttpStatusCode statusCode,
                                      string body,
                                      string contentType = HttpResponse.DefaultContentType);
    }
}
