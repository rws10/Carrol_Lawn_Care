using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Carrol_Lawn_Care.Startup))]
namespace Carrol_Lawn_Care
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
