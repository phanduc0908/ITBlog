using ITBLOG.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Configuration
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(c => c.CommnentId);
            builder.Property(c => c.Name).HasMaxLength(30).IsRequired();
            builder.Property(c => c.Content).IsRequired().IsRequired();

            // Config Relation
            builder.HasOne(c => c.blog)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.BlogId)
                .IsRequired();
        }
    }
}
