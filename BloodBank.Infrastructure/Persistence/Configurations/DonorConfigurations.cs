using BloodBank.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    public class DonorConfigurations : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasOne(a => a.Address)
                .WithOne()
                .HasForeignKey<Address>(a => a.DonorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
