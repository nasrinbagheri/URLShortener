using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URLShortener.Domain;

namespace URLShortener.DataAccess.DomainConfigurations
{
    public class LinkTicketConfiguration : IEntityTypeConfiguration<LinkTicket>
    {
        public void Configure(EntityTypeBuilder<LinkTicket> builder)
        {
            builder.ToTable("LinkTicket").HasKey(t => t.Id);
            builder.Property(t => t.Domain).HasMaxLength(260);
            builder.Property(t => t.OriginalUrl).IsRequired().HasMaxLength(2000);
            builder.Property(t => t.ShortenUrl).HasMaxLength(300);
            builder.Property(t => t.VisitedCount);
        }
    }
}
