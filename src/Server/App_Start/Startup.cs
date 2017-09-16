using BonosIndependiente.Server;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup), "Configuration")]
namespace BonosIndependiente.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}