using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLShortener.DataAccess.Contracts;
using URLShortener.Encryption.Contracts;

namespace URLShortener.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILinkTicketService _ticketService;
        private readonly IHashIdService _hashIdService;

        public ValuesController(ILinkTicketService ticketService, IHashIdService hashIdService)
        {

            _ticketService = ticketService;
            _hashIdService = hashIdService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var test = _hashIdService.Encrypt(100);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
