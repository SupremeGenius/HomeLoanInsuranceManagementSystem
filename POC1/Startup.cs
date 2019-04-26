using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POC1.Startup))]
namespace POC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
