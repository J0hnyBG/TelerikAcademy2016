namespace ConsoleWebServer.Framework.Contracts
{
    public interface IActionDescriptor
    {
        string ControllerName { get; }

        string ActionName { get; }

        string Parameter { get; }
    }
}
