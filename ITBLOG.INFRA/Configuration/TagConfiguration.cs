using System;
using System.Collections.Generic;
using System.Text;
using ITBLOG.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITBLOG.INFRA.Configuration
{
    class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(t => t.TagId);
            builder.Property(t => t.TagName).IsRequired();
            
            //  Config relation
            builder.HasOne(t => t.blog)
                .WithMany(t => t.Tags)
                .HasForeignKey(t => t.BlogId)
                .IsRequired();
        }
    }
}
