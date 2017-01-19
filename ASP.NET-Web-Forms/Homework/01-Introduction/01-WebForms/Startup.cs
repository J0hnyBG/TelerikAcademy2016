using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01_WebForms.Startup))]
namespace _01_WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            this.ConfigureAuth(app);
        }
    }
}
