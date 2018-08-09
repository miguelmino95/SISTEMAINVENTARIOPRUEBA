using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaInventarios.Startup))]
namespace SistemaInventarios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
