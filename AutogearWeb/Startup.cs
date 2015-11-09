using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutogearWeb.Startup))]
namespace AutogearWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
