using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Payments.Api.WebHost.Models
{
    public class PaymentsInMemory : IPayments
    {
        private ConcurrentBag<Payment> _payments;

        public PaymentsInMemory()
        {
            if (_payments == null)
            {
                FillResidentsBag();
            }
        }

        public IEnumerable<Payment> Get()
        {
            return _payments;
        }

        public Payment Get(Guid id)
        {
            return _payments.SingleOrDefault(p => p.Id == id);
        }

        public void Add(Payment payment)
        {
            _payments.Add(payment);
        }

        private void FillResidentsBag()
        {
            _payments = new ConcurrentBag<Payment>();

            _payments.Add(new Payment
            {
                Id = Guid.Parse("b97bdd2a-ad0b-4465-80fa-9d27bca72649"),
                HomeId = 2734,
                CheckNumber = "827364819",
                Received = DateTime.Parse("11/14/2014"),
                Amount = 50.00m
            });

            _payments.Add(new Payment
            {
                Id = Guid.Parse("24724ab6-4ed5-40cd-a947-c7be142d1b2d"),
                HomeId = 2732,
                CheckNumber = "2301",
                Received = DateTime.Parse("11/11/2014"),
                Amount = 50.00m
            });

            _payments.Add(new Payment
            {
                Id = Guid.Parse("c2c74c7a-31b0-49fa-83bb-a1bd38e7ffd8"),
                HomeId = 2719,
                CheckNumber = "3065",
                Received = DateTime.Parse("11/13/2014"),
                Amount = 50.00m
            });
        }
    }
}