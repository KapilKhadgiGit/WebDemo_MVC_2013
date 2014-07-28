using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVCDemo.Web.Startup))]
namespace WebMVCDemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
