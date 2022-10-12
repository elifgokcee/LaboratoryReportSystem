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
    public class RoleManager : RoleService
    {
        private IRoleDal roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            this.roleDal = roleDal;
        }

        public bool Add(Role entity)
        {
            try
            {

                return roleDal.Add(entity);
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

                return roleDal.Delete(id);
            }
            catch
            {
                throw new Exception("Couldn't delete");
            }
        }

        public List<Role> GetAll()
        {
            try
            {

                return roleDal.Get();
            }
            catch
            {
                throw new Exception("Couldn't find");
            }
        }

        public Role GetById(int id)
        {
            try
            {

                return roleDal.GetById(id);
            }
            catch
            {
                throw new Exception("Couldn't find");
            }
        }

        public bool Update(Role entity)
        {
            try
            {

                return roleDal.Update(entity);
            }
            catch
            {
                throw new Exception("Couldn't update");
            }
        }
    }
}
