using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetWebServeurV2.Startup))]
namespace ProjetWebServeurV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
