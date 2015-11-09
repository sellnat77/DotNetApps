using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(serviceApp.Startup))]
namespace serviceApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
