using System.Reflection;

using Ninject;

using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
