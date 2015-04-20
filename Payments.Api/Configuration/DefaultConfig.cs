using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Payments.Api.Configuration
{
    public class DefaultConfig
    {
        public void Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
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
