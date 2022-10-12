using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Abstracts
{
    public interface DiagnosisService : IEntityService<Diagnosis>
    {
        int GetLastId();
      
    }
}
