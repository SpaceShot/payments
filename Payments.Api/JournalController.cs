using System.Net.Http;
using System.Web.Http;

namespace Payments.Api
{
    public class JournalController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse();
        }
    }
}
