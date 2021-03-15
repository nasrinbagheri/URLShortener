using System;
using System.Collections.Generic;
using System.Text;

namespace URLShortener.DataAccess.Contracts
{
    public interface ILinkTicketService
    {
        void GetAllRequestsAsync();
    }
}
