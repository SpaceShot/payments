using Payments.Api.Controllers;
using Payments.Data.InMemory;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Xunit;

namespace Payments.Api.WebHost.Tests
{
    public class PaymentsJsonTests
    {
        public PaymentsJsonTests()
        {
            var residenceController = new ResidenceController(new ResidentsInMemory());
            var paymentsController = new PaymentsController(new PaymentsInMemory());
        }

        [Fact]
        public void GetFromResidenceReturnsSuccessStatusCode()
        {
            var config = new HttpConfiguration();

            config.Services.Replace(
                typeof(IHttpControllerActivator),
                new HardWiredControllerActivator(new ResidentsInMemory(), new PaymentsInMemory())
            );

            config.Routes.MapHttpRoute(
                name: "Testing Api",
                routeTemplate: "{controller}/{id}",
                defaults: new {
                    id = RouteParameter.Optional
                });

            var server = new HttpServer(config);
            var client = new HttpClient(server);
            client.BaseAddress = new Uri("http://inmemory.testing");

            using (client)
            {
                var result = client.GetAsync("Residence").Result;
                Assert.True(result.IsSuccessStatusCode, "Actual Status Code: " + result.StatusCode);
            }
        }

        [Fact]
        public void GetSpecificResidenceReturnsThatResidence()
        {
            var config = new HttpConfiguration();

            config.Services.Replace(
                typeof(IHttpControllerActivator),
                new HardWiredControllerActivator(new ResidentsInMemory(), new PaymentsInMemory())
            );

            config.Routes.MapHttpRoute(
                name: "Testing Api",
                routeTemplate: "{controller}/{id}",
                defaults: new {
                    id = RouteParameter.Optional
                });

            var server = new HttpServer(config);
            var client = new HttpClient(server);
            client.BaseAddress = new Uri("http://inmemory.testing");

            using (client)
            {
                var result = client.GetAsync("Residence/2734").Result;
                Assert.True(result.IsSuccessStatusCode, "Actual Status Code: " + result.StatusCode);
            }
        }
    }
}
