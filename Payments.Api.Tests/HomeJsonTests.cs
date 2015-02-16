using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Payments.Api.Tests
{
    public class HomeJsonTests
    {
        [Fact]
        public void GetResponseReturnCorrectStatusCode()
        {
            using (var client = HttpClientFactory.Create())
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
            using (var client = HttpClientFactory.Create())
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
            using (var client = HttpClientFactory.Create())
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

    public static class JsonExtensions
    {
        public static Task<dynamic> ReadAsJsonAsync(this HttpContent content)
        {
            if (content == null)
                throw new ArgumentNullException("content");

            return content.ReadAsStringAsync().ContinueWith(t =>
                JsonConvert.DeserializeObject(t.Result));
        }

        public static dynamic ToJObject<T>(this T obj)
        {
            dynamic serialized = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject(serialized);
        }
    }
}
