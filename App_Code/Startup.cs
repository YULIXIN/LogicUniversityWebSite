using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginUniversityWebSite.Startup))]
namespace LoginUniversityWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
