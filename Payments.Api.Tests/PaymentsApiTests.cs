using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payments.Api.Controllers;
using Payments.Api.Models;
using System.Web.Http.Results;

namespace Payments.Api.Tests
{
    [TestClass]
    public class PaymentsApiTests
    {
        private PaymentsController _paymentsController;
        private IPayments _payments;

        [TestInitialize]
        public void TestSetup()
        {
            _payments = new PaymentsInMemory();
            _paymentsController = new PaymentsController(_payments);
        }

        [TestMethod]
        public void Constructing_A_Payments_Controller_Returns_Type_PaymentsController()
        {
            Assert.AreEqual(_paymentsController.GetType(), typeof(PaymentsController));
        }

        [TestMethod]
        public void Get_Payments_Returns_Correct_Length_Of_Items()
        {
            var result = _paymentsController.Get() as OkNegotiatedContentResult<IEnumerable<Payment>>;
            
            Assert.AreEqual(_payments.Get().Count(), result.Content.Count());
        }
    }
}
