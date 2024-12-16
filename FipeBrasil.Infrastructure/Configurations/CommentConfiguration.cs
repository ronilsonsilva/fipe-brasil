using FipeBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FipeBrasil.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AuthorName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.AuthorEmail).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Text).IsRequired().HasMaxLength(500);
            builder.Property(c => c.CreatedAt).IsRequired();
        }
    }
}
