using Payments.Core.Models;
using System;
using System.Web.Http;

namespace Payments.Api.Controllers
{
    public class PaymentsController : ApiController
    {
        private readonly IPayments _payments;

        public PaymentsController(IPayments payments)
        {
            this._payments = payments;
        }

        public IHttpActionResult Get()
        {
            return Ok(_payments.Get());
        }

        public IHttpActionResult Get(string id)
        {
            var payment = _payments.Get(Guid.Parse(id));
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        public IHttpActionResult Post(Payment payment)
        {
            var guid = Guid.NewGuid();
            payment.Id = guid;
            _payments.Add(payment);

            return CreatedAtRoute<Payment>("DefaultApi", new
                {
                    controller = "Payments",
                    id = guid.ToString()
                },
                payment);
        }
    }
}