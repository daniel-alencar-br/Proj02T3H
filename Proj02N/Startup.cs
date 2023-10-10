using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proj02N.Startup))]
namespace Proj02N
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
