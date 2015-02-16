using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Payments.Api.Controllers
{
    public class JournalController : ApiController
    {
        private readonly static List<JournalEntryModel> entries = new List<JournalEntryModel>();

        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, new JournalModel { Entries = entries.ToArray() });
        }

        public HttpResponseMessage Post(JournalEntryModel journalEntry)
        {
            entries.Add(journalEntry);
            return this.Request.CreateResponse();
        }
    }
 
    public class JournalEntryModel
    {
        public DateTimeOffset Time { get; set; }
        public int Distance { get; set; }
        public TimeSpan Duration { get; set; }
    }
 
    public class JournalModel
    {
        public JournalEntryModel[] Entries { get; set; }
    }
}
