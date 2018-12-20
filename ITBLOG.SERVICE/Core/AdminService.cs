using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.SERVICE.Core
{
    public interface IAdminService
    {
        Admin GetAdmin(string username, string password);
    }
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin GetAdmin(string username, string password)
        {
            return _adminRepository.GetAdminAccount(username,password);
        }

    }
}
