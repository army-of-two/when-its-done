using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhenItsDone.WebFormsClient.Startup))]
namespace WhenItsDone.WebFormsClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
