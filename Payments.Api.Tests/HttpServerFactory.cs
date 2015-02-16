using System;
using Microsoft.Owin.Hosting;

namespace Payments.Api.Tests
{
    public class HttpServerFactory
    {
        private IDisposable _server;

        public HttpServerFactory(string baseAddress="http://localhost:9876")
        {
            _server = WebApp.Start<Startup>(url: baseAddress);
        }

        public void StopServer()
        {
            _server.Dispose();
        }
    }
}