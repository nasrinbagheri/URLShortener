using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using URLShortener.DataAccess.Dtos;

namespace URLShortener.DataAccess.Contracts
{
    public interface ILinkTicketService
    {
        void GetAllRequestsAsync();
        Task<LinkTicketDto> Add(string originalUrl);
    }
}
