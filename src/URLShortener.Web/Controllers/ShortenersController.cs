using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using URLShortener.IntegrationService.Contracts;
using URLShortener.Web.Dtos;

namespace URLShortener.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ShortenersController : BaseController
    {
        private readonly IURlShortenerService _shortenerService;
        public ShortenersController(IURlShortenerService shortenerService, IMapper mapper) : base(mapper)
        {
            _shortenerService = shortenerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost]
        public async Task<ResultDto<string>> Post([FromBody] ShortenDto dto)
        {
            //todo: check null
            var result = await _shortenerService.AddLinkTicket(dto.Url).ConfigureAwait(false);
            //todo: if (result==null)
            
            var retVal = ToResultDto<string, string>(result.ShortenUrl); ;
            return retVal;
        }
    }
}
