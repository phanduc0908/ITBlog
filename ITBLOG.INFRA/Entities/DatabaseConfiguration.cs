using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.INFRA.Entities
{
    class DatabaseConfiguration : ConfigurationBase
    {
        private readonly string ConnectionString = "DBConnectionString";

        public string GetConnectionString()
        {
            return GetConfiguration().GetConnectionString(ConnectionString);
        }
    }
}
