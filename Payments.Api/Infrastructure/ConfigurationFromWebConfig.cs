using System;
using System.Linq;
using System.Configuration;

namespace Payments.Api.Infrastructure
{
    public class ConfigurationFromWebConfig
    {
        private readonly string _clientAddress;

        public string ClientAddress
        {
            get
            {
                return _clientAddress;
            }
        }

        public ConfigurationFromWebConfig()
        {
            _clientAddress = ConfigurationManager.AppSettings["clientAddress"];
        }
    }
}