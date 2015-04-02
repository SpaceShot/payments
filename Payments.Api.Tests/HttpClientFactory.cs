using Payments.Api.Routes;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Payments.Api.Tests
{
    public class HttpClientFactory
    {
        public static HttpClient Create()
        {
            var config = new HttpConfiguration();
            RouteConfig.Configure(config);

            var server = new HttpServer(config);
            var client = new HttpClient(server);
            client.BaseAddress = new Uri("http://inmemory.testing");
            return client;
        }
    }
}