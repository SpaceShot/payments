using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payments.Api.WebHost.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Payments.Api.WebHost.Models;

namespace Payments.Api.Tests
{
    [TestClass]
    public class PaymentsControllerTests
    {
        private PaymentsController _paymentsController;
        private IPayments _payments;
        private Payment _singlePayment;
        private Payment _newPayment;

        [TestInitialize]
        public void TestSetup()
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

        [TestMethod]
        public void Constructing_A_Payments_Controller_Returns_Type_PaymentsController()
        {
            Assert.IsInstanceOfType(_paymentsController, typeof(PaymentsController));
        }

        [TestMethod]
        public void Get_Payments_Returns_Correct_Length_Of_Items()
        {
            var result = _paymentsController.Get() as OkNegotiatedContentResult<IEnumerable<Payment>>;
            
            Assert.AreEqual(result.Content.Count(), _payments.Get().Count());
        }

        [TestMethod]
        public void Get_Payments_By_Id_Returns_Correct_Payment()
        {
            var result = _paymentsController.Get("b97bdd2a-ad0b-4465-80fa-9d27bca72649")
                as OkNegotiatedContentResult<Payment>;

            Assert.AreEqual(_singlePayment, result.Content);
        }

        [TestMethod]
        public void Get_Payments_With_Invalid_Id_Returns_NotFound()
        {
            var result = _paymentsController.Get(Guid.Empty.ToString());

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Post_Payment_Returns_Created_Result()
        {
            var result = _paymentsController.Post(_newPayment);

            Assert.IsInstanceOfType(result, typeof(CreatedNegotiatedContentResult<Payment>));
        }

        [TestMethod]
        public void Post_Payment_Adds_Payment_To_Payments_Store()
        {
            var result = _paymentsController.Post(_newPayment) as CreatedNegotiatedContentResult<Payment>;
            var returnedId = result.Content.Id;

            var payment = _payments.Get(returnedId);

            Assert.AreEqual(_newPayment, payment);
        }
    }
}
