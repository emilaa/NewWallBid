using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WallBid.Infrastructure.Entities;

namespace WallBid.Data.Persistences.Configurations
{
    internal class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(m => m.Logo).HasColumnType("nvarchar").HasMaxLength(150);

            builder.HasKey(m => m.Id);
            builder.ConfigureAsAuditable();
            builder.ToTable("Brands");
        }
    }
}
