using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Color = WallBid.Infrastructure.Entities.Color;


namespace WallBid.Data.Persistences.Configurations
{
    internal class ColorEntityConfigration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50);


            builder.HasKey(m => m.Id);
            builder.ConfigureAsAuditable();
            builder.ToTable("Colors");
        }

    }
}
