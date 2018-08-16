using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieReview.WebMVC.Startup))]
namespace MovieReview.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
