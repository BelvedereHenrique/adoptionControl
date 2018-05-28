using Owin;
using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(Desafio.Startup))]
namespace Desafio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
