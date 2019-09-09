using SalaryApp.DataLayer.Core;
using SalaryApp.DataLayer.Core.Repositories;
using SalaryApp.DataLayer.Persistence.Repositories;
using System;

namespace SalaryApp.DataLayer.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository Employees { get; private set; }
        public IWorkshopRepository Workshops { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IWorkgroupRepository Workgroups { get; private set; }
        public IFinancialYearRepository FinancialYears { get; private set; }
        public IWorkPlaceRepository Workplaces { get; private set; }
        public IPayRepository Pays { get; private set; }
        public ISalaryPayDetails SalaryDetails { get; private set; }
        public IAnnualPayDetailRepository AnnualDetails { get; private set; }
        public IEducationRepository Educations { get; private set; }
        public IPayTypeRepository PayTypes { get; private set; }

        private readonly SalaryContext context;

        public UnitOfWork(SalaryContext context)    
        {
            this.context = context;

            Employees = new EmployeeRepository(context);
            Workshops = new WorkshopRepository(context);
            Cities = new CityRepository(context);
            Workgroups = new WorkgroupRepository(context);
            FinancialYears = new FinancialYearRepository(context);
            Workplaces = new WorkplaceRepository(context);
            Pays = new PayRepository(context);
            SalaryDetails = new SalaryPayDetailsRepository(context);
            AnnualDetails = new AnnualPayDetailRepository(context);
            Educations = new EducationRepository(context);
            PayTypes = new PayTypeRepository(context);
        }



        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
