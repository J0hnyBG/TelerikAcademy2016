namespace ConsoleWebServer.Framework.HttpMessages.Contracts
{
    public interface IHttpResponse : IHttpMessage
    {
        string Body { get; }
    }
}
