using Payments.Api.Controllers;
using Payments.Api.Models;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Payments.Api.Infrastructure
{
    public class ControllerActivator : IHttpControllerActivator
    {
        private readonly IResidents _residents;

        public ControllerActivator(IResidents residents)
        {
            this._residents = residents;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == typeof(ResidenceController))
            {
                return new ResidenceController(_residents);
            }

            else throw new ArgumentException("Controller not recognized", "controllerType");
        }
    }
}