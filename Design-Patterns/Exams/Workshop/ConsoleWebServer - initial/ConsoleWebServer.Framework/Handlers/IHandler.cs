using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.Handlers
{
    public interface IHandler
    {
        IHandler Next { get; set; }

        IHttpResponse HandleRequest(IHttpRequest request);
    }
}
