using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.DataAccess.Concretes;
using LaboratoryReportProject.Entities;
using LaboratoryReportProject.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Concrete
{
    public class ReportManager : ReportService
    {
        private AdonetReportDal _adonetReportDal;
        public ReportManager(AdonetReportDal adonetReportDal)
        {
            _adonetReportDal = adonetReportDal;
        }
    
        public bool Add(Report entity)
        {
            try
            {
                return _adonetReportDal.Add(entity);
            }
            catch
            {
                throw new Exception("Couldn't add");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _adonetReportDal.Delete(id); 
            }
            catch
            {
                throw new Exception("Couldn't delete");
            }
        }

        public bool DeleteReportByPateientId(int patientId)
        {
            List<ReportDetails> reportDetails = _adonetReportDal.GetReportDetailsByPatientId(patientId).ToList();
            try
            {
                foreach (var report in reportDetails)
                {

                    _adonetReportDal.Delete(report.Id);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<Report> GetAll()
        {
            return _adonetReportDal.Get();
        }

        public Report GetById(int id)
        {
            try 
            { 
                return _adonetReportDal.GetById(id);
            }
            catch
            {
                throw new Exception("Couldn't find");
            }
        }

        public List<ReportDetails> GetReportDetails()
        {
            return _adonetReportDal.GetReportDetails();
        }

        public List<ReportDetails> GetReportDetailsById(int id)
        {
            return _adonetReportDal.GetReportDetailsById(id);
        }

        public List<ReportDetails> GetReportDetailsByPatientId(int id)
        {
            try
            {
                return _adonetReportDal.GetReportDetailsByPatientId(id);
            }
            catch
            {
                throw new Exception("Couldn't find");
            }
        }

        public List<ReportDetails> GetReportDetailsByPatientName(string PatientName)
        {
            return _adonetReportDal.GetReportDetailsByPatientName(PatientName);
        }

        public bool Update(Report entity)
        {
            try
            {
                return _adonetReportDal.Update(entity);
            }
            catch
            {
                throw new Exception("Couldn't update");
            }
        }
    }
}
