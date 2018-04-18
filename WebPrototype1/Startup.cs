using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPrototype1.Startup))]
namespace WebPrototype1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
