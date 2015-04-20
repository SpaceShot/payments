using Payments.Api.WebHost.Infrastructure;
using Payments.Core.Models;
using StructureMap;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Payments.Api.WebHost.Configuration
{
    public static class ControllerConfig
    {
        public static void Configure(HttpConfiguration config, IPayments payments, IResidents residents)
        {
            ObjectFactory.Configure(cfg =>
            {
                cfg.For<IResidents>().Use(residents).Singleton();
                cfg.For<IPayments>().Use(payments).Singleton();
            });

            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapControllerActivator());
        }
    }
}