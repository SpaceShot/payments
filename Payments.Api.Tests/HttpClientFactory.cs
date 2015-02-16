using System;
using System.Net.Http;

namespace Payments.Api.Tests
{
    public class HttpClientFactory
    {
        public static HttpClient Create()
        {
            var baseAddress = "http://localhost:9876";
            var client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(baseAddress);
                return client;
            }
            catch
            {
                client.Dispose();
                throw;
            }
        }
    }
}