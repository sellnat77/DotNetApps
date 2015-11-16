using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksApplication.Startup))]
namespace BooksApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
