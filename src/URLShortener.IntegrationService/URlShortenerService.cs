using System;
using System.Threading.Tasks;
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
        public URlShortenerService(ILinkTicketService linkTicketService, IHashIdService hashIdService)
        {
            _linkTicketService = linkTicketService;
            _hashIdService = hashIdService;
        }

        public async Task<LinkTicketDto> AddLinkTicket(string url)
        {
            var result = await _linkTicketService.AddAsync(url).ConfigureAwait(false);
            //todo: if (result==null)

            var hashedId = _hashIdService.Encrypt(result.Id);

            result = await _linkTicketService.UpdateShortenLinkTicketAsync(result.Id, hashedId);
            return result;
        }
    }
}
