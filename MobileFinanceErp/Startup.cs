using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileFinanceErp.Startup))]
namespace MobileFinanceErp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
