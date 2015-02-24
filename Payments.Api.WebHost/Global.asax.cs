using Payments.Api.WebHost.Infrastructure;
using Payments.Core.Models;
using Payments.Data.InMemory;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace Payments.Api.WebHost
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
 
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var hostConfig = new ConfigurationFromWebConfig();

            // Web API configuration and services
            var cors = new EnableCorsAttribute(hostConfig.AllowedOrigins, "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Persistence creation and injection into controllers
            var residents = new ResidentsInMemory();
            var payments = new PaymentsInMemory();
            
            ObjectFactory.Configure(cfg =>
            {
                cfg.For<IResidents>().Use<ResidentsInMemory>(residents).Singleton();
                cfg.For<IPayments>().Use<PaymentsInMemory>(payments).Singleton();
            });

            // Web API Dependency Injection
            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapControllerActivator());
        }
    }
}