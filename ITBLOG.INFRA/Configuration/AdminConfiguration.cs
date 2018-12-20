
using ITBLOG.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admin");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Username).HasMaxLength(30).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(20).IsRequired();
        }
    }
}
