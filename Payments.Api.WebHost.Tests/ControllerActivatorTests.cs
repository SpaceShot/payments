using Payments.Api.Controllers;
using Payments.Api.WebHost.Infrastructure;
using Payments.Core.Models;
using System;
using Xunit;

namespace Payments.Api.WebHost.Tests
{
    internal class ControllerActivatorTests
    {
        private readonly IResidents _residents = null;
        private readonly IPayments _payments = null;

        [Fact]
        internal void Creates_A_ResidenceController()
        {
            var controllerActivator = new ControllerActivator(_residents, _payments);
            var controller = controllerActivator.Create(null, null, typeof(ResidenceController));

            Assert.IsType<ResidenceController>(controller);
        }

        [Fact]
        internal void Creates_A_PaymentsController()
        {
            var controllerActivator = new ControllerActivator(_residents, _payments);
            var controller = controllerActivator.Create(null, null, typeof(PaymentsController));

            Assert.IsType<PaymentsController>(controller);
        }

        [Fact]
        internal void Throws_Exception_For_Unrecognized_ControllerType()
        {
            var controllerActivator = new ControllerActivator(_residents, _payments);

            Assert.Throws<ArgumentException>(() => 
                controllerActivator.Create(null, null, typeof(System.String))
                );
        }
    }
}
