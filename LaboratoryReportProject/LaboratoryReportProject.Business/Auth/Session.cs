using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Auth
{
    public class Session
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int LaborantId { get; set; } 
        public string LaborantNameAndSurname { get; set; }  
    }
}