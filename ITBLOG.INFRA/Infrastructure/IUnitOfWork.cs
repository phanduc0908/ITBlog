using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
