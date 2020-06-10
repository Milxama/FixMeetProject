using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FixMeetWebApi.Startup))]
namespace FixMeetWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
