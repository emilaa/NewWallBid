﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WallBid.Infrastructure.Entities;

namespace WallBid.Data.Persistences.Configurations
{
    internal class ModelEntityConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50);

            builder.HasKey(m => m.Id);
            builder.ConfigureAsAuditable();
            builder.ToTable("Model");
        }
    }
}
