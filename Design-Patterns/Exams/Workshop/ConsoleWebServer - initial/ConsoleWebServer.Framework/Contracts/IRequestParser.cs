using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IRequestParser
    {
        IHttpRequest Parse(string requestAsString);
    }
}
