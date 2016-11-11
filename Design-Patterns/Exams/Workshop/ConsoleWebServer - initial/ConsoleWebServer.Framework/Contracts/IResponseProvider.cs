using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IResponseProvider
    {
        IHttpResponse GetResponse(string requestAsString);
    }
}
