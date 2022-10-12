using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.Business.ServiceAdapters;
using LaboratoryReportProject.DataAccess.Abstracts;
using LaboratoryReportProject.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Concrete
{
    public class PatientManager : PatientService
    {
        private IPatientDal _patientDal;
        private  IKpsService _kpsService;
        public PatientManager(IPatientDal patientDal,IKpsService service)
        {
            this._patientDal = patientDal;
           this. _kpsService=service;    
        }
    
        public bool Add(Patient entity)
        {
        

            try
            {
                return _patientDal.Add(entity);

            }
            catch
            {
                throw new Exception("Patient could not be confirmed");

            }
           
        }

        public bool Delete(int id)
        {
            try
            {
                return _patientDal.Delete(id);
            }
            catch
            {
                throw new Exception("Patient couldn't delete");
            }
        }

        public List<Patient> GetAll()
        {
            return _patientDal.Get();
        }

        public Patient GetById(int id)
        {
            try
            {
                return _patientDal.GetById(id);
            }
            catch
            {
                throw new Exception("Couldn't find");
            }
        }

        public List<Patient> GetPatientByIdentityNumber(string IdentityNumber)
        {
            return _patientDal.GetByIdentityNumber(IdentityNumber);
        }

        public bool Update(Patient entity)
        {
            try
            {
                return _patientDal.Update(entity);
            }
            catch { throw new Exception("Patient could not be confirmed"); }
           
       
        }
    }
}
