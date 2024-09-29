using BloodBank.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BloodBank.Infrastructure.Persistence
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) :base(options)
        {

        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StockBlood> StockBloods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
