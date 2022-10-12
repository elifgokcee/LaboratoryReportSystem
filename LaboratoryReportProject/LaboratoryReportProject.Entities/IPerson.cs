using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Entities
{
    public interface IPerson
    {
         int Id { get; set; }
         string Name { get; set; }
         string SurName { get; set; }
         string IdentityNumber { get; set; }
         DateTime BirthDate { get; set; }
       
    }
}
