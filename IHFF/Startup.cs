using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IHFF.Startup))]
namespace IHFF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
