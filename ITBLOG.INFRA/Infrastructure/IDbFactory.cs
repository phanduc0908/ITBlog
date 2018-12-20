using ITBLOG.INFRA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ITBlogEntities Init();
    }
}
