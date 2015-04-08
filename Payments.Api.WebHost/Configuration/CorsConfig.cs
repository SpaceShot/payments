using Payments.Api.WebHost.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Payments.Api.WebHost.Configuration
{
    public static class CorsConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            var hostConfig = new ConfigurationFromWebConfig();

            // Web API configuration and services
            var cors = new EnableCorsAttribute(hostConfig.AllowedOrigins, "*", "*");
            config.EnableCors(cors);
        }
    }
}