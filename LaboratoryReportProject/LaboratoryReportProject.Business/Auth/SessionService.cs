using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Auth
{
    public interface SessionService
    {
        void DeadSession(Session session);  
    }
}
