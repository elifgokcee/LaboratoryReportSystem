using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.DataAccess
{
    public static class Database
    {

      
            public static SqlConnection GetConnection()
            {
                return new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=LaboratoryReportProject ;integrated security=true;");
            }
        
    }
}
