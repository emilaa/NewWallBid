using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WallBid.Infrastructure.Entities;

namespace WallBid.Data.Persistences.Configurations
{
    public class BodyTypeEntityConfigration
    {
        public void Configure(EntityTypeBuilder<BodyType> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100);


            builder.HasKey(m => m.Id);
            builder.ConfigureAsAuditable();
            builder.ToTable("BodyTypes");
        }
    }
}
