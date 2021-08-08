using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(maShop.WebUI.Startup))]
namespace maShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
