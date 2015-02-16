using System.Web.Http;
using Owin;

namespace Payments.Api.Tests
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            new Bootstrap().Configure(config);

            app.UseWebApi(config);
        }
    }
}