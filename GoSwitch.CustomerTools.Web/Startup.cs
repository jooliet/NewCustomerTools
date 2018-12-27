using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoSwitch.CustomerTools.Web.Startup))]
namespace GoSwitch.CustomerTools.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
