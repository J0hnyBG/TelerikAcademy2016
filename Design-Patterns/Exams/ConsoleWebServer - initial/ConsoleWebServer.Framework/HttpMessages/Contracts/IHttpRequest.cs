using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework.HttpMessages.Contracts
{
    public interface IHttpRequest : IHttpMessage
    {
        string Uri { get; }

        string Method { get; }

        IActionDescriptor Action { get; }
    }
}
