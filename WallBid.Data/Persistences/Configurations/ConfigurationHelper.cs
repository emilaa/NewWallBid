using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Data.Persistences.Configurations
{
    public static class ConfigurationHelper
    {
        public static EntityTypeBuilder<T> ConfigureAsAuditable<T>(this EntityTypeBuilder<T> builder) where T : AuditableEntity
        {
            builder.Property(m => m.CreatedBy).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.LastModifiedBy).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");

            return builder;
        }
    }
}
