using Payments.Api.Controllers;
using Payments.Api.Routes;
using Payments.Core.Models;
using Payments.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Xunit;

namespace Payments.Api.Tests
{
    public class PaymentsControllerTests
    {
        private readonly PaymentsController _paymentsController;
        private readonly IPayments _payments;
        private readonly Payment _singlePayment;
        private readonly Payment _newPayment;

        public PaymentsControllerTests()
        {
            _payments = new PaymentsInMemory();
            _singlePayment = _payments.Get(Guid.Parse("b97bdd2a-ad0b-4465-80fa-9d27bca72649"));
            _newPayment = new Payment
            {
                Id = Guid.Parse("0798C75D-7352-4104-B769-9E62786DFD2B"),
                HomeId = 2734,
                CheckNumber = "2003",
                Received = DateTime.Parse("8/4/2014"),
                Amount = 137.50m
            };

            _paymentsController = new PaymentsController(_payments);
        }

        [Fact]
        public void Constructing_A_Payments_Controller_Returns_Type_PaymentsController()
        {
            Assert.IsType<PaymentsController>(_paymentsController);
        }

        [Fact]
        public void Get_Payments_Returns_Correct_Length_Of_Items()
        {
            var result = _paymentsController.Get() as OkNegotiatedContentResult<IEnumerable<Payment>>;
            
            Assert.Equal(_payments.Get().Count(), result.Content.Count());
        }

        [Fact]
        public void Get_Payments_By_Id_Returns_Correct_Payment()
        {
            var result = _paymentsController.Get("b97bdd2a-ad0b-4465-80fa-9d27bca72649")
                as OkNegotiatedContentResult<Payment>;

            Assert.Equal(_singlePayment, result.Content);
        }

        [Fact]
        public void Get_Payments_With_Invalid_Id_Returns_NotFound()
        {
            var result = _paymentsController.Get(Guid.Empty.ToString());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_Payment_Returns_Created_Result()
        {
            var result = _paymentsController.Post(_newPayment);

            Assert.IsType<CreatedAtRouteNegotiatedContentResult<Payment>>(result);
        }

        [Fact]
        public void Post_Payment_Returns_Location_Header()
        {
            var result = _paymentsController.Post(_newPayment) as CreatedAtRouteNegotiatedContentResult<Payment>;

            Assert.NotNull(result);
        }

        [Fact]
        public void Post_Payment_Returns_Correct_Location_Header()
        {
            var result = _paymentsController.Post(_newPayment) as CreatedAtRouteNegotiatedContentResult<Payment>;

            Assert.Equal("DefaultApi", result.RouteName);
            Assert.NotNull(result.RouteValues["id"]);
        }

        [Fact]
        public void Post_Payment_Adds_Payment_To_Payments_Store()
        {
            var result = _paymentsController.Post(_newPayment) as CreatedAtRouteNegotiatedContentResult<Payment>;
            var returnedId = result.Content.Id;

            var payment = _payments.Get(returnedId);

            Assert.Equal(_newPayment, payment);
        }
    }
}
