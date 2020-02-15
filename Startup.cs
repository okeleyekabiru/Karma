using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shopy.Startup))]
namespace Shopy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
