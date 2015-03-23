using System.Collections.Generic;

namespace Payments.Core.Models
{
    public interface IResidents
    {
        IEnumerable<Residence> Get();
        Residence Get(int id);
    }
}
