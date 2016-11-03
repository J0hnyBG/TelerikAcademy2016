using System.Reflection;

using Dealership.Engine.Contracts;

using Ninject;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var engine = kernel.Get<IDealershipEngine>();
            engine.Start();
        }
    }
}
