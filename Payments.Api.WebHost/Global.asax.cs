using Payments.Api.WebHost.Infrastructure;
using Payments.Api.WebHost.Models;
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
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
 
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var hostConfig = new ConfigurationFromWebConfig();

            // Web API configuration and services
            var cors = new EnableCorsAttribute(hostConfig.ClientAddress, "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var residents = new ResidentsInMemory();
            var payments = new PaymentsInMemory();
            config.Services.Replace(typeof(IHttpControllerActivator), new ControllerActivator(residents,payments));
        }
    }
}