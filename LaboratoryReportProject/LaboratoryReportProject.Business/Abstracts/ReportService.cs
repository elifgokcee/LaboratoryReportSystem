using LaboratoryReportProject.Entities;
using LaboratoryReportProject.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Abstracts
{
    public interface ReportService : IEntityService<Report>
    {
        List<ReportDetails> GetReportDetails();
        List<ReportDetails> GetReportDetailsById(int id);
        List<ReportDetails> GetReportDetailsByPatientName(string PatientName);
        List<ReportDetails> GetReportDetailsByPatientId(int id);
        bool DeleteReportByPateientId(int id);

    }
}
