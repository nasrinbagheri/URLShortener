using System.Threading.Tasks;
using URLShortener.DataAccess.Dtos;

namespace URLShortener.DataAccess.Contracts
{
    public interface ILinkTicketService
    {
        void GetAllRequestsAsync();
        Task<LinkTicketDto> GetLinkTicketByIdAsync(int id);
        Task<LinkTicketDto> AddAsync(string originalUrl);
        Task<LinkTicketDto> UpdateShortenLinkTicketAsync(int id, string domain, string shortUrl);
        Task<LinkTicketDto> VisitShortenLinkTicketAsync(int id);
    }
}
