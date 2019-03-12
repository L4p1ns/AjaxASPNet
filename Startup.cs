using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxLapin.Startup))]
namespace AjaxLapin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
