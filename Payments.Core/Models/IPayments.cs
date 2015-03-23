using System;
using System.Collections.Generic;

namespace Payments.Core.Models
{
    public interface IPayments
    {
        IEnumerable<Payments.Core.Models.Payment> Get();

        Payments.Core.Models.Payment Get(Guid id);

        void Add(Payments.Core.Models.Payment payment);
    }
}