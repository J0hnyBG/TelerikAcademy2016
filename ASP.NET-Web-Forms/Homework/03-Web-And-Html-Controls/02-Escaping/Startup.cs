using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02_Escaping.Startup))]
namespace _02_Escaping
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            this.ConfigureAuth(app);
        }
    }
}
