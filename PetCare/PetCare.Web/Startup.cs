using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetCare.Web.Startup))]
namespace PetCare.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
