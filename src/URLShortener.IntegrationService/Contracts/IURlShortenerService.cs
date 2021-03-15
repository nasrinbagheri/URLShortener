using System.Threading.Tasks;
using URLShortener.DataAccess.Dtos;

namespace URLShortener.IntegrationService.Contracts
{
    public interface IURlShortenerService
    {
        Task<LinkTicketDto> AddLinkTicket(string url);
    }
}
