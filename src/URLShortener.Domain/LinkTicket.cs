using System;
using URLShortener.Common.ErrorTypes;
using URLShortener.Common.Exceptions;

namespace URLShortener.Domain
{
    public class LinkTicket
    {
        public LinkTicket(string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl))
                throw new BusinessException<LinkTicketErrorType>(LinkTicketErrorType.InvalidUrl);

            OriginalUrl = originalUrl;
        }

        public int Id { get; set; }
        public string Domain { get; set; }
        public string ShortenUrl { get; set; }
        public string OriginalUrl { get; set; }
        public int VisitedCount { get; set; }

        public void UpdateShortenUrl(string domain, string shortenUrl)
        {
            if (string.IsNullOrEmpty(domain))
                throw new BusinessException<LinkTicketErrorType>(LinkTicketErrorType.InvalidDomain);

            if (string.IsNullOrEmpty(shortenUrl))
                throw new BusinessException<LinkTicketErrorType>(LinkTicketErrorType.InvalidUrl);

            Domain = domain;
            ShortenUrl = shortenUrl;
        }

        public void Visited()
        {
            VisitedCount = VisitedCount + 1;
        }
    }
}
