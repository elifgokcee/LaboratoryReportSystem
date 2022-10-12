using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Entities
{
    public class Report : IEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }  
        public int DiagnosisId { get; set; }    
        public DateTime CreatedDate { get; set; }
        public int LaborantId { get; set; } 
    }
}
