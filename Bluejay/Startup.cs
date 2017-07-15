using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bluejay.Startup))]
namespace Bluejay
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
