
using ITBLOG.INFRA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ITBlogEntities dbContext;

        public ITBlogEntities Init()
        {
            return dbContext ?? (dbContext = new DbContentFactory().CreateDbContext(null));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
