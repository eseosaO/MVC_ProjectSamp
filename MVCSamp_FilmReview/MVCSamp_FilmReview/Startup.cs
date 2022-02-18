using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSamp_FilmReview.Startup))]
namespace MVCSamp_FilmReview
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
