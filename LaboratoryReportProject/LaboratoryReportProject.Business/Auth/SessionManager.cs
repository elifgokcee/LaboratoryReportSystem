using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Auth
{
    public class SessionManager : SessionService
    {
        public void DeadSession(Session session)
        {
            session.UserName = "";
            session.Password = "";
            session.RoleId = -1;
        }
    }
}
