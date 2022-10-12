using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.DataAccess.Abstracts
{
    public interface IEntityDal<IEntity>
    {

        List<IEntity> Get();
        bool Add(IEntity entity);
        bool Delete(int id);
        bool Update(IEntity entity);
        IEntity GetById(int id);
    }
}
