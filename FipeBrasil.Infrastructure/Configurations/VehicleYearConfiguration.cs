using FipeBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FipeBrasil.Infrastructure.Data.Configurations
{
    public class VehicleYearConfiguration : IEntityTypeConfiguration<VehicleYear>
    {
        public void Configure(EntityTypeBuilder<VehicleYear> builder)
        {
            builder.HasKey(vy => vy.Id);
            builder.Property(vy => vy.Code).IsRequired().HasMaxLength(10);
            builder.Property(vy => vy.Name).IsRequired().HasMaxLength(50);
        }
    }
}
