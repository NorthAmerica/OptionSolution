using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OP.Brochure.Startup))]
namespace OP.Brochure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
