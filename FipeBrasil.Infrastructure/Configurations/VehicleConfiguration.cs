using FipeBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FipeBrasil.Infrastructure.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.VehicleType).IsRequired();
            builder.Property(v => v.Price).IsRequired().HasMaxLength(50);
            builder.Property(v => v.BrandName).IsRequired().HasMaxLength(100);
            builder.Property(v => v.ModelName).IsRequired().HasMaxLength(100);
            builder.Property(v => v.ModelYear).IsRequired();
            builder.Property(v => v.FuelType).IsRequired().HasMaxLength(20);
            builder.Property(v => v.FipeCode).IsRequired().HasMaxLength(15);
            builder.Property(v => v.ReferenceMonth).IsRequired().HasMaxLength(50);
            builder.Property(v => v.FuelAbbreviation).IsRequired().HasMaxLength(5);
        }
    }
}
