using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.Business.Auth;
using LaboratoryReportProject.Business.Concrete;
using LaboratoryReportProject.Business.ServiceAdapters;
using LaboratoryReportProject.DataAccess.Abstracts;
using LaboratoryReportProject.DataAccess.Concretes;

using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {

        public override void Load()
        {
            Bind<DiagnosisService>().To<DiagnosisManager>().InSingletonScope();
            Bind<ReportService>().To<ReportManager>().InSingletonScope();
            Bind<LaborantService>().To<LaborantManager>().InSingletonScope();
            Bind<PatientService>().To<PatientManager>().InSingletonScope();
            Bind<RoleService>().To<RoleManager>().InSingletonScope();


            Bind<IPatientDal>().To<AdonetPatientDal>().InSingletonScope();
            Bind<ILaborantDal>().To<AdonetLaborantDal>().InSingletonScope();
            Bind<IReportDal>().To<AdonetReportDal>().InSingletonScope();
            Bind<IRoleDal>().To<AdonetRoleDal>().InSingletonScope();
            Bind<IDiagnosisDal>().To<AdonetDiagnosisDal>().InSingletonScope();

            Bind<SessionService>().To<SessionManager>().InSingletonScope();

            Bind<IKpsService>().To<KpsServiceAdapter>().InSingletonScope();
        }
    
    }
}
