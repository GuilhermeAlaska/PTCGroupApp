using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Persistence.Maps
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(nameof(Post));

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id);

            builder.Property(p => p.Title).HasMaxLength(30).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(40).IsRequired();
            builder.Property(p => p.FullPost).HasMaxLength(400).IsRequired();
            builder.Property(p => p.Category).IsRequired();
        }
    }
}