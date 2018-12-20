using System;
using System.Collections.Generic;
using System.Text;
using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Configuration;
using Microsoft.EntityFrameworkCore;
namespace ITBLOG.INFRA.Entities
{
    public class ITBlogEntities : DbContext
    {
        public ITBlogEntities(DbContextOptions<ITBlogEntities> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        //Configuaration for code first
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Master Table Config
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            //Seed
            ITBlogSeedEntities.Run(modelBuilder);
        }
    }
}
