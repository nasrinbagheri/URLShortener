using Microsoft.EntityFrameworkCore;
using System;
using URLShortener.DataAccess.Contracts;
using URLShortener.DataAccess.DomainConfigurations;
using URLShortener.Domain;

namespace URLShortener.DataAccess
{
    public class DataAccessContext : DbContext, IDbContext
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options)
        {
        }


        public virtual DbSet<LinkTicket> LinkTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LinkTicketConfiguration());
            //modelBuilder.pl.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
