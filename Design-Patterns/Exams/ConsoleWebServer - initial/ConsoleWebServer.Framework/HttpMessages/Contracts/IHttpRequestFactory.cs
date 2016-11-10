namespace ConsoleWebServer.Framework.HttpMessages.Contracts
{
    public interface IHttpRequestFactory
    {
        IHttpRequest GetHttpRequest(string method, string uri, string httpVersion);
    }
}
