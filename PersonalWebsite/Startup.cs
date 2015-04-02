using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalWebsite.Startup))]
namespace PersonalWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
