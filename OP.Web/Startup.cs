using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OP.Web.Startup))]
namespace OP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
