using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoSwitch.CustomerTools.Startup))]
namespace GoSwitch.CustomerTools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
