using LaboratoryReportProject.Core;
using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.DataAccess.Abstracts
{
    public interface IDiagnosisDal: IEntityDal<Diagnosis>
    {
        int GetLastId();
       
     


    }
}
