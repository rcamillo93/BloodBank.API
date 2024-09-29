using BloodBank.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    public class StockBloodConfigurations : IEntityTypeConfiguration<StockBlood>
    {
        public void Configure(EntityTypeBuilder<StockBlood> builder)
        {
            builder
                .HasKey(sb => sb.Id);
        }
    }
}
