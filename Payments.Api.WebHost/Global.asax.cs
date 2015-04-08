using Payments.Api.WebHost.Configuration;
using Payments.Data.InMemory;
using System;
using System.Web.Http;

namespace Payments.Api.WebHost
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiRegistration.ComposeConfiguration);
        }
    }

    public class WebApiRegistration
    {
        public static void ComposeConfiguration(HttpConfiguration config)
        {
            // Persistence creation
            var residents = new ResidentsInMemory();
            var payments = new PaymentsInMemory();

            CorsConfig.Configure(config);
            RouteConfig.Configure(config);
            ControllerConfig.Configure(config, payments, residents);
        }
    }
}