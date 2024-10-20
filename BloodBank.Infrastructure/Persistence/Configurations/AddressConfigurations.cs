using BloodBank.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.CityId)
                .IsRequired();

            builder
                .Property(a => a.DonorId)
                .IsRequired();

            builder
                .Property(a => a.Neighborhood)
                .IsRequired();

            builder
                .Property(a => a.PublicPlace)
                .IsRequired()
                .HasMaxLength(100);       

            //builder
            //   .HasOne(a => a.City)
            //   .WithMany(c => c.Addresses)
            //   .HasForeignKey(a => a.CityId)
            //   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
