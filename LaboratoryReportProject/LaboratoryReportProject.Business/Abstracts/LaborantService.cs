using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Abstracts
{
    public interface LaborantService : IEntityService<Laborant>
    {
        bool IsVerifyLaborant(string username, string password);
        Laborant GetLaborantByUserName(string UserName);
        Laborant GetLaborantByIdentity(string identity);
    }
}
