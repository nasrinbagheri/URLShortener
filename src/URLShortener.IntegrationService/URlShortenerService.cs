using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using URLShortener.Common.ErrorTypes;
using URLShortener.Common.Exceptions;
using URLShortener.DataAccess.Contracts;
using URLShortener.DataAccess.Dtos;
using URLShortener.Encryption.Contracts;
using URLShortener.IntegrationService.Contracts;

namespace URLShortener.IntegrationService
{
    public class URlShortenerService : IURlShortenerService
    {
        private readonly ILinkTicketService _linkTicketService;
        private readonly IHashIdService _hashIdService;
        private readonly string _defaultDomain;
        public URlShortenerService(ILinkTicketService linkTicketService, IHashIdService hashIdService
            , IOptions<URlShortenerOptions> options)
        {
            _linkTicketService = linkTicketService;
            _hashIdService = hashIdService;
            _defaultDomain = options.Value.DefaultDomain;
        }

        public async Task<LinkTicketDto> AddLinkTicket(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new BusinessException<LinkTicketErrorType>(LinkTicketErrorType.InvalidUrl);

            var result = await _linkTicketService.AddAsync(url).ConfigureAwait(false);
            if (result == null)
                throw new BusinessException<LinkTicketErrorType>(LinkTicketErrorType.ErrorInInsertion);

            var hashedId = _hashIdService.Encrypt(result.Id);

            var shortenUrl = $"{_defaultDomain}/{hashedId}";
            result = await _linkTicketService.UpdateShortenLinkTicketAsync(result.Id, _defaultDomain, shortenUrl);
            return result;

            //todo: handle duplicate errorr
        }

        public async Task<LinkTicketDto> VisitLinkTicket(string relativeShortenUrl)
        {
            //todo: locking the action
            var deCodedShortenUrlId = _hashIdService.Decrypt(relativeShortenUrl);

            var result = await _linkTicketService.VisitShortenLinkTicketAsync((int)deCodedShortenUrlId).ConfigureAwait(false);
            return result;

            //todo: handle duplicate errorr
        }

        public async Task<LinkTicketDto> GetVisitCountReportAsync(string relativeShortenUrl)
        {
            var deCodedShortenUrlId = _hashIdService.Decrypt(relativeShortenUrl);

            var result = await _linkTicketService.GetLinkTicketByIdAsync((int)deCodedShortenUrlId);

            return result;
        }
    }
}
