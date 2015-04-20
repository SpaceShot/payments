using Payments.Api.Configuration;
using Payments.Data.InMemory;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Payments.Api.AcceptanceTests
{
    public class HttpClientBuilder
    {
        public static HttpClient Build()
        {
            var config = new HttpConfiguration();

            return Build(config);
        }

        public static HttpClient Build(HttpConfiguration config)
        {
            new DefaultConfig().Configure(config);

            config.Services.Replace(typeof(IHttpControllerActivator), new HardWiredControllerActivator(new ResidentsInMemory(), new PaymentsInMemory()));

            var server = new HttpServer(config);
            var client = new HttpClient(server);

            client.BaseAddress = new Uri("http://inmemory.testing");
            return client;
        }
    }
}
