using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_03_WebAPI.Startup))]

namespace _03_WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
