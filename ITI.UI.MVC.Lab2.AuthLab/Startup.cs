using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITI.UI.MVC.Lab2.AuthLab.Startup))]
namespace ITI.UI.MVC.Lab2.AuthLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
