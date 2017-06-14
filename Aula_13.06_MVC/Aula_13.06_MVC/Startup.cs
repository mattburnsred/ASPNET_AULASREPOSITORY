using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aula_13._06_MVC.Startup))]
namespace Aula_13._06_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
