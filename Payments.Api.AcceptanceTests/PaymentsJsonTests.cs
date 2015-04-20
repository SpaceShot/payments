using System.Linq;
using System.Web.Http;
using Xunit;

namespace Payments.Api.AcceptanceTests
{
    public class PaymentsJsonTests
    {
        [Fact]
        public void Assembly_Resolver_Finds_Api_Assembly()
        {
            var config = new HttpConfiguration();
            var client = HttpClientBuilder.Build(config);

            var apiAssemblyName = "Payments.Api";

            var assembliesResolver = config.Services.GetAssembliesResolver();
            var assemblies = assembliesResolver.GetAssemblies();

            var assemblyNames = assemblies.Select(a => a.FullName.Split(new char[] { ',' }).First());

            var result = assemblyNames.Any(n => n == apiAssemblyName);

            Assert.True(result, "Did not find " + apiAssemblyName);
        }

        [Fact]
        public void Get_From_Residence_Returns_Success_Status_Code()
        {
            using (var client = HttpClientBuilder.Build())
            {
                var result = client.GetAsync("Residence").Result;
                Assert.True(result.IsSuccessStatusCode, "Actual Status Code: " + result.StatusCode);
            }
        }

        [Fact]
        public void Get_Specific_Residence_Returns_That_Residence()
        {
            using (var client = HttpClientBuilder.Build())
            {
                var result = client.GetAsync("Residence/2734").Result;
                Assert.True(result.IsSuccessStatusCode, "Actual Status Code: " + result.StatusCode);
            }
        }
    }
}
