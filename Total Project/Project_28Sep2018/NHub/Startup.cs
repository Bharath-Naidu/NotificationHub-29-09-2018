using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHub.Startup))]
namespace NHub
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
