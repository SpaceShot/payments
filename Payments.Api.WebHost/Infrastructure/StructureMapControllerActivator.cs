using StructureMap;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Payments.Api.WebHost.Infrastructure
{
    public class StructureMapControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IHttpController;
        }
    }
}