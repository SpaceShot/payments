using Payments.Api.Routes;
using Payments.Api.WebHost.Infrastructure;
using Payments.Core.Models;
using Payments.Data.InMemory;
using StructureMap;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;

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

            Cors.Configure(config);
            RouteConfig.Configure(config);
            Controllers.Configure(config, payments, residents);
        }
    }

    public static class Cors
    {
        public static void Configure(HttpConfiguration config)
        {
            var hostConfig = new ConfigurationFromWebConfig();

            // Web API configuration and services
            var cors = new EnableCorsAttribute(hostConfig.AllowedOrigins, "*", "*");
            config.EnableCors(cors);
        }
    }

    public static class Controllers
    {
        public static void Configure(HttpConfiguration config, IPayments payments, IResidents residents)
        {
            ObjectFactory.Configure(cfg =>
            {
                cfg.For<IResidents>().Use(residents).Singleton();
                cfg.For<IPayments>().Use(payments).Singleton();
            });

            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapControllerActivator());
        }
    }
}