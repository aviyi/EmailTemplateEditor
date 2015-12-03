using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmailTemplateWeb.Startup))]
namespace EmailTemplateWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
