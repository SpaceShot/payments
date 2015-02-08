using Payments.Api.WebHost.Models;
using System.Web.Http;

namespace Payments.Api.WebHost.Controllers
{
    public class ResidenceController : ApiController
    {
        private readonly IResidents _residents;

        public ResidenceController(IResidents residents)
        {
            _residents = residents;
        }
        
        public IHttpActionResult Get()
        {
            return Ok(_residents.Get());
        }

        public IHttpActionResult Get(int id)
        {
            var resident = _residents.Get(id);
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }
    }
}
