using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.Business.ServiceAdapters;
using LaboratoryReportProject.Business.VerifyPerson.LibraryManagamentSystem.Core.Utilities.Auth;
using LaboratoryReportProject.DataAccess.Abstracts;
using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Concrete
{
    public class LaborantManager : LaborantService
    {
        private ILaborantDal _laborantDal;
        private IKpsService _kpsService;
        public LaborantManager(ILaborantDal laborantDal, IKpsService kpsService)
        {
            _laborantDal = laborantDal;
            _kpsService = kpsService;
        }
    
        public bool Add(Laborant entity)
        {
          
                entity.Password= VerifyUser.HashPassword(entity.Password);
                return _laborantDal.Add(entity);
           
            throw new Exception("Laborant could not be confirmed");
        }

        public bool Delete(int id)
        {
            try
            {
                 return _laborantDal.Delete(id);
            }
            catch
            {
                throw new Exception("Coludn't delete");
            }
        }

        public List<Laborant> GetAll()
        {
            return _laborantDal.Get();
        }

        public Laborant GetById(int id)
        {
            try
            {
                return _laborantDal.GetById(id);
            }
            catch
            {
                throw new Exception("Laborant couldn't find ");
            }
           
        }

        public Laborant GetLaborantByIdentity(string identity)
        {
          return  _laborantDal.Get().Where(x => x.IdentityNumber == identity).SingleOrDefault();
        }

        public Laborant GetLaborantByUserName(string UserName)
        {
            try
            {
                return _laborantDal.GetLaborantByUserName(UserName);
            }
            catch
            {
                throw new Exception("Couldn't find");
            }
        }

        public bool IsVerifyLaborant(string username, string password)
        {
            Laborant laborant = _laborantDal.GetLaborantByUserName(username);
            bool result = false;
            if (laborant != null) {
                 result = VerifyUser.VerifyHashedPassword(laborant.Password,password);
            }
            return result;
        }

        public bool Update(Laborant entity)
        {
            if (_kpsService.ValidatePerson(entity))
            {
                entity.Password = VerifyUser.HashPassword(entity.Password);
                return _laborantDal.Update(entity);
            }
            throw new Exception("Laborant could not be confirmed");
        }
    }
}
