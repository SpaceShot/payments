using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace Payments.Api.Tests
{
    public class HttpClientFactory : IDisposable
    {
        private readonly IDisposable _server;
        private readonly string _baseAddress = "http://localhost:9876";

        public HttpClientFactory()
        {
            _server = WebApp.Start<Startup>(url: _baseAddress);
        }

        public void Dispose()
        {
            _server.Dispose();
        }

        public HttpClient Create()
        {
            var client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(_baseAddress);
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