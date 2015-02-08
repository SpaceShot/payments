using System.Collections.Generic;

namespace Payments.Api.WebHost.Models
{
    public interface IResidents
    {
        IEnumerable<Residence> Get();
        Residence Get(int id);
    }
}
