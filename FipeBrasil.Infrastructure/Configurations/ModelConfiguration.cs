using FipeBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FipeBrasil.Infrastructure.Data.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Code).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(m => m.Years).WithOne(y => y.Model).HasForeignKey(y => y.ModelId);
        }
    }
}
