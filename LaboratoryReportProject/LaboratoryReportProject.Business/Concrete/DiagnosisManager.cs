using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.DataAccess.Abstracts;
using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Concrete
{
    public class DiagnosisManager : DiagnosisService
    {
        private IDiagnosisDal _diagnosisDal;
        public DiagnosisManager(IDiagnosisDal diagnosisDal)
        {
            _diagnosisDal = diagnosisDal;   
                
        }
        public bool Add(Diagnosis entity)
        {
           
          
                Diagnosis diagnosis = entity;
                return _diagnosisDal.Add(entity);
            
       
        }

      

        public bool Delete(int id)
        {
            try
            {

               return _diagnosisDal.Delete(id);
            }
            catch
            {
                throw new Exception("Couldn't delete");
            }
        }

        public List<Diagnosis> GetAll()
        {
            try
            {

                return _diagnosisDal.Get();
            }
            catch
            {
                throw new Exception("Couldn't delete");
            }
        }

        public Diagnosis GetById(int id)
        {
            try
            {

                return _diagnosisDal.GetById(id);
            }
            catch
            {
                throw new Exception("Couldn't find");
            }
        }

        public int GetLastId()
        {
          return _diagnosisDal.GetLastId(); 
        }

        public bool Update(Diagnosis entity)
        {
            try
            {

                return _diagnosisDal.Update(entity);
            }
            catch
            {
                throw new Exception("Couldn't update");
            }
        }
    }
}
