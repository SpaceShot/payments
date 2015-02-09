using System.Net.Http;
using System.Web.Http;

namespace Payments.Api.Controllers
{
    public class JournalController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse();
        }
    }
}
