using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootballAccountant.Startup))]
namespace FootballAccountant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
