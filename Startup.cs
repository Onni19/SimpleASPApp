using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleASPApp.Startup))]
namespace SimpleASPApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
