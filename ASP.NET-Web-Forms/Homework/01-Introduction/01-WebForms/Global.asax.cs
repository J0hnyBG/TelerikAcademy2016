using System;
using System.Reflection;
using System.Web.Optimization;
using System.Web.Routing;

using Ninject;
using Ninject.Web.Common;

namespace _01_WebForms
{
    public class Global : NinjectHttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}