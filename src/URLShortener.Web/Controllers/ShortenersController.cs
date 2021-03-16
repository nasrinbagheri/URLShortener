using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using URLShortener.IntegrationService.Contracts;
using URLShortener.Web.WriteDtos;

namespace URLShortener.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ShortenersController : ControllerBase
    {
        private readonly IURlShortenerService _shortenerService;
        public ShortenersController(IURlShortenerService shortenerService)
        {
            _shortenerService = shortenerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShortenDto dto)
        {
            //todo: check null
            var test = await _shortenerService.AddLinkTicket(dto.Url).ConfigureAwait(false);
            return Ok(null);
        }
    }
}
