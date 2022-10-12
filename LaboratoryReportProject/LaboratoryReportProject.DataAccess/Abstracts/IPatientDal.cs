using LaboratoryReportProject.Core;
using LaboratoryReportProject.Entities;
using LaboratoryReportProject.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.DataAccess.Abstracts
{
    public interface IPatientDal : IEntityDal<Patient>
    {
        List<Patient> GetByIdentityNumber(string IdentityNumber);
       
    }
}
