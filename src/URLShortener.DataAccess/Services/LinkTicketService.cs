using System;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.DataAccess.Contracts;
using URLShortener.DataAccess.Dtos;
using URLShortener.Domain;

namespace URLShortener.DataAccess.Services
{
    public class LinkTicketService : ILinkTicketService
    {
        private readonly IRepository<LinkTicket> _repository;
        public LinkTicketService(IRepository<LinkTicket> repository)
        {
            _repository = repository;
        }

        public void GetAllRequestsAsync()
        {
            var t = _repository.Table.ToList();
        }

        public async Task<LinkTicketDto> Add(string originalUrl)
        {
            //todo: if (string.IsNullOrEmpty(originalUrl))


            var uri = new Uri(originalUrl);
            var domain = $"{uri.Scheme}://{uri.Authority}";

            var model = new LinkTicket { OriginalUrl = originalUrl, Domain = domain };
            await _repository.InsertAsync(model);

            var result = new LinkTicketDto
            {
                Domain = model.Domain,
                OriginalUrl = model.OriginalUrl,
                Id = model.Id,
                ShortenUrl = model.ShortenUrl,
                VisitedCount = model.VisitedCount
            };
            return result;
        }
    }
}
