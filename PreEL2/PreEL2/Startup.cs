using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PreEL2.Startup))]
namespace PreEL2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
