using ConsoleWebServer.Framework.ActionResults;
using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework.Handlers
{
    public interface IActionInvoker
    {
        IActionResult InvokeAction(Controller controller, IActionDescriptor actionDescriptor);
    }
}
