﻿using FipeBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FipeBrasil.Infrastructure.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Code).IsRequired().HasMaxLength(10);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(b => b.Models).WithOne(m => m.Brand).HasForeignKey(m => m.BrandId);
        }
    }
}
