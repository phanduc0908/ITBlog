using ITBLOG.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Configuration
{
    class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog");
            builder.HasKey(r => r.BlogId);
            builder.Property(r => r.Author).HasMaxLength(50).IsRequired();
            builder.Property(r => r.Title).IsRequired();
            builder.Property(r => r.Genre).HasMaxLength(50).IsRequired();
            builder.Property(r => r.Content).IsRequired();
            builder.Property(r => r.Image).IsRequired();
            builder.Property(r => r.ContentHeader).IsRequired();
            builder.Property(r => r.ReleaseDay).HasDefaultValueSql("getDate()");
        }
    }
}
