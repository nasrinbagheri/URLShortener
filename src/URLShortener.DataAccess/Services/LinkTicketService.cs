﻿using System;
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

        public async Task<LinkTicketDto> AddAsync(string originalUrl)
        {
            //todo: if (string.IsNullOrEmpty(originalUrl))

            //var uri = new Uri(originalUrl);
            //var domain = $"{uri.Scheme}://{uri.Authority}";

            var model = new LinkTicket { OriginalUrl = originalUrl };
            await _repository.InsertAsync(model);

            var result = ToModel(model);
            return result;
        }

        public async Task<LinkTicketDto> UpdateShortenLinkTicketAsync(int id, string domain, string shortUrl)
        {
            var ticket = await _repository.GetByIdAsync(id);
            //todo:if (ticket==null)

            ticket.UpdateShortenUrl(domain, shortUrl);
            await _repository.UpdateAsync(ticket);

            var result = ToModel(ticket);
            return result;
        }

        public async Task<LinkTicketDto> VisitShortenLinkTicketAsync(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            //todo:if (ticket==null)
            ticket.Visited();
            await _repository.UpdateAsync(ticket);

            var result = ToModel(ticket);
            return result;
        }
        private LinkTicketDto ToModel(LinkTicket model)
        {
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
