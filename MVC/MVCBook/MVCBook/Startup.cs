using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBook.Startup))]
namespace MVCBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
