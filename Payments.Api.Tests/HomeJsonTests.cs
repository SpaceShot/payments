using System;
using System.Net.Http;
using Xunit;

namespace Payments.Api.Tests
{
    public class HomeJsonTests : IUseFixture<HttpClientFactory>
    {
        private HttpClientFactory _httpClientFactory;

        public void SetFixture(HttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Fact]
        public void GetResponseReturnCorrectStatusCode()
        {
            using (var client = _httpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;

                Assert.True(
                    response.IsSuccessStatusCode,
                    "Actual status code: " + response.StatusCode);
            }
        }

        [Fact]
        public void PostReturnsResponseWithCorrectStatusCode()
        {
            using (var client = _httpClientFactory.Create())
            {
                var json = new
                {
                    time = DateTimeOffset.Now,
                    distance = 8500,
                    duration = TimeSpan.FromMinutes(44)
                };

                var response = client.PostAsJsonAsync("", json).Result;

                Assert.True(
                    response.IsSuccessStatusCode,
                    "Actual status code: " + response.StatusCode);
            }
        }

        [Fact]
        public void GetAfterPostReturnsResponseWithPostedEntry()
        {
            using (var client = _httpClientFactory.Create())
            {
                var json = new
                {
                    time = DateTimeOffset.Now,
                    distance = 8500,
                    duration = TimeSpan.FromMinutes(44)
                };

                var expected = json.ToJObject();

                client.PostAsJsonAsync("", json).Wait();

                var response = client.GetAsync("").Result;

                var actual = response.Content.ReadAsJsonAsync().Result;

                Assert.Contains(expected, actual.entries);
            }
        }
    }
}
