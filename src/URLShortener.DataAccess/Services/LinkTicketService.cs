using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using URLShortener.DataAccess.Contracts;
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
    }
}
