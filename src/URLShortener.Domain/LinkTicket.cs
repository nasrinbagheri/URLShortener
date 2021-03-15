using System;

namespace URLShortener.Domain
{
    public class LinkTicket
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public string ShortenUrl { get; set; }
        public string OriginalUrl { get; set; }
        public int VisitedCount { get; set; }
    }
}
