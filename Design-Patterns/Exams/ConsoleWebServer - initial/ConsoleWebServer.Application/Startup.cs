using System.Reflection;

using ConsoleWebServer.Application.WebServer;

using Ninject;

namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var webSever = kernel.Get<IWebServerConsole>();

            //new WebServerConsole(
            //    new ResponseProvider(new RequestParser(null),
            //                         null,
            //                         new ControllerHandler(null, new ActionInvoker())),
            //    new ConsoleInputOutputProvider());
            webSever.Start();
        }
    }
}
