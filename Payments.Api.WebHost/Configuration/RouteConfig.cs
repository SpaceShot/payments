using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Payments.Api.WebHost.Configuration
{
    public static class RouteConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                                defaults: new
                                {
                                    id = RouteParameter.Optional
                                }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}
