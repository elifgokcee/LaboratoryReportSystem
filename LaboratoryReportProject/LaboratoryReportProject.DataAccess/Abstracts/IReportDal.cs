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
    public interface IReportDal : IEntityDal<Report>
    {
        List<ReportDetails> GetReportDetails();
        List<ReportDetails> GetReportDetailsById(int id);
        List<ReportDetails> GetReportDetailsByPatientName(string PatientName);
        List<ReportDetails> GetReportDetailsByPatientId(int patientId);
    }
}
