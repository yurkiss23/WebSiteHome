using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSiteHome.Startup))]
namespace WebSiteHome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
