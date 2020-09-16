using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProblemStatement2.Startup))]
namespace ProblemStatement2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
