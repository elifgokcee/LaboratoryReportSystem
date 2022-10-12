using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Entities.ComplexTypes
{
    public class ReportDetails
    {
        public int Id { get; set; } 
        public string PatientName { get; set; } 
        public string PatientIdentityNumber { get; set; }   
        public string DiagnosisTitle { get; set; }  
        public string DiagnosisDescription { get; set; }    
        public DateTime CreatedDate { get; set; }   
        public string LaborantName { get; set; }    

    }
}
