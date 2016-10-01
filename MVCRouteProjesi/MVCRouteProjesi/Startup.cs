using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCRouteProjesi.Startup))]
namespace MVCRouteProjesi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
