using BloodBank.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    public class DonationsConfigurations : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasOne(d => d.Donor)
                .WithMany(dn => dn.Donations)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
