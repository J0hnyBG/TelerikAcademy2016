using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_04_SPA.Startup))]

namespace _04_SPA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
