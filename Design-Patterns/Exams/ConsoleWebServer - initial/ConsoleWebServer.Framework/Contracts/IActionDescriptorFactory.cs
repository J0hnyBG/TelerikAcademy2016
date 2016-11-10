namespace ConsoleWebServer.Framework.Contracts
{
    public interface IActionDescriptorFactory
    {
        IActionDescriptor GetActionDescriptor(string uri);
    }
}
