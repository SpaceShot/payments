using System;

namespace Payments.Api.WebHost.Models
{
    public class Payment
    {
        public Guid Id;
        public int HomeId;
        public decimal Amount;
        public string CheckNumber;
        public DateTime Received;
    }
}