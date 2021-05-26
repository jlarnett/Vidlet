using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidlet.Startup))]
namespace Vidlet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
