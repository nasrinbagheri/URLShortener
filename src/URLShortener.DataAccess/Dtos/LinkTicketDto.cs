namespace URLShortener.DataAccess.Dtos
{
    public class LinkTicketDto
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public string ShortenUrl { get; set; }
        public string OriginalUrl { get; set; }
        public int VisitedCount { get; set; }
    }
}
