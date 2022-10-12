using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Abstracts
{
    public interface PatientService : IEntityService<Patient>
    {
        List<Patient> GetPatientByIdentityNumber(string IdentityNumber);
    }
}
