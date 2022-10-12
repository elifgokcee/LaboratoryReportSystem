
using LaboratoryReportProject.Business.ServiceAdapters;
using LaboratoryReportProject.Business.ServiceReference1;
using LaboratoryReportProject.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.ServiceAdapters
{
    public class KpsServiceAdapter : IKpsService
    {
       

        public bool ValidatePerson(IPerson person)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient();
          return  client.TCKimlikNoDogrula(
                Convert.ToInt64(person.IdentityNumber),
                    person.Name.ToUpper(),
                    person.SurName.ToUpper(),
                    person.BirthDate.Year);
        }
    }
}
