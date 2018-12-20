using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Entities
{
    public class DbContentFactory : IDesignTimeDbContextFactory<ITBlogEntities>
    {
        private static string ConnectionString => new DatabaseConfiguration().GetConnectionString();
        public ITBlogEntities CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ITBlogEntities>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new ITBlogEntities(optionsBuilder.Options);
        }
    }
}
