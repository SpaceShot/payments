using Payments.Api.Controllers;
using Payments.Core.Models;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Payments.Api.WebHost.Infrastructure
{
    public class ControllerActivator : IHttpControllerActivator
    {
        private readonly IResidents _residents;
        private readonly IPayments _payments;


        public ControllerActivator(IResidents residents, IPayments payments)
        {
            this._residents = residents;
            this._payments = payments;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == typeof(ResidenceController))
            {
                return new ResidenceController(_residents);
            }
            else if (controllerType == typeof(PaymentsController))
            {
                return new PaymentsController(_payments);
            }

            else throw new ArgumentException("Controller not recognized", "controllerType");
        }
    }
}