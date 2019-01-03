using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoSwitch.CustomerTools.Admin.Startup))]
namespace GoSwitch.CustomerTools.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
