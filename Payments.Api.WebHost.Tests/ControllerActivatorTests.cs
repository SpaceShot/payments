using System;
using Payments.Api.WebHost.Controllers;
using Payments.Api.WebHost.Infrastructure;
using Payments.Api.WebHost.Models;
using Xunit;

namespace Payments.Api.WebHost.Tests
{
    public class ControllerActivatorTests
    {
        private IResidents residents;
        private IPayments payments;

        [Fact]
        public void Creates_A_ResidenceController()
        {
            var controllerActivator = new ControllerActivator(residents, payments);
            var controller = controllerActivator.Create(null, null, typeof(ResidenceController));

            Assert.IsType<ResidenceController>(controller);
        }

        [Fact]
        public void Creates_A_PaymentsController()
        {
            var controllerActivator = new ControllerActivator(residents, payments);
            var controller = controllerActivator.Create(null, null, typeof(PaymentsController));

            Assert.IsType<PaymentsController>(controller);
        }

        [Fact]
        public void Throws_Exception_For_Unrecognized_ControllerType()
        {
            var controllerActivator = new ControllerActivator(residents, payments);

            Assert.Throws<ArgumentException>(() => 
                controllerActivator.Create(null, null, typeof(System.String))
                );
        }
    }
}
