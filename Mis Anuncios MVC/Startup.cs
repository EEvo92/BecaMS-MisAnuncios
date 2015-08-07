using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mis_Anuncios_MVC.Startup))]
namespace Mis_Anuncios_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
