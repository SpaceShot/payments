using System.Collections.Generic;

namespace Payments.Api.Models
{
    public interface IResidents
    {
        IEnumerable<Residence> Get();
        Residence Get(int id);
    }
}
