using System;
using System.Linq;
using System.Configuration;

namespace Payments.Api.WebHost.Infrastructure
{
    public class ConfigurationFromWebConfig
    {
        private readonly string _allowedOrigins;

        public string AllowedOrigins
        {
            get
            {
                return _allowedOrigins;
            }
        }

        public ConfigurationFromWebConfig()
        {
            _allowedOrigins = ConfigurationManager.AppSettings["allowedOrigins"];
        }
    }
}