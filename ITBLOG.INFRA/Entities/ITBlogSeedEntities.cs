using ITBLOG.CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Entities
{
    public class ITBlogSeedEntities
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(

            );
            modelBuilder.Entity<Tag>().HasData(

            );
            modelBuilder.Entity<Comment>().HasData(

            );
            modelBuilder.Entity<Admin>().HasData(

            );
        }
    }
}
