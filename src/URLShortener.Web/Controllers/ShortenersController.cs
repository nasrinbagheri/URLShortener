using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using URLShortener.Common.ErrorTypes;
using URLShortener.Common.Exceptions;
using URLShortener.DataAccess.Dtos;
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

        [HttpPost]
        public async Task<ResultDto<string>> Post([FromBody] ShortenDto dto)
        {
            if (dto == null)
                throw new BusinessException<CommonErrorType>(CommonErrorType.NullArguments);

            var result = await _shortenerService.AddLinkTicket(dto.Url).ConfigureAwait(false);

            if (result == null)
                throw new BusinessException<LinkTicketErrorType>(LinkTicketErrorType.ErrorInShortenUrlUpdate);

            var retVal = ToResultDto<string, string>(result.ShortenUrl);
            return retVal;
        }

        [HttpGet("{code}/visit-report")]
        public async Task<ResultDto<LinkTicketReportDto>> GetVisitCount(string code)
        {
            var result = await _shortenerService.GetVisitCountReportAsync(code).ConfigureAwait(false);
            var retVal = ToResultDto<LinkTicketDto, LinkTicketReportDto>(result);
            return retVal;
        }
    }
}
