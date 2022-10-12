using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.Abstracts
{
    public interface IEntityService<IEntity>
    {
         List<IEntity> GetAll();
        IEntity GetById(int id);
        bool Delete(int id);
        bool Add(IEntity entity);

        bool Update(IEntity entity);    

    }
}
