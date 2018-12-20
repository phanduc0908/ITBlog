using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITBLOG.INFRA.Repositories
{
    public interface IAdminRepository
    {
        Admin GetAdminAccount(string username, string password);
    }
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Admin GetAdminAccount(string username, string password)
        {
            var Admin = this.DbContext.Admins
                .Where(a => a.Username.Equals(username) && a.Password.Equals(password))
                .SingleOrDefault();
            return Admin;
        }
    }
}
