using SalaryApp.DataLayer.Core;
using SalaryApp.DataLayer.Core.Repositories;
using SalaryApp.DataLayer.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalaryContext context;

        public UnitOfWork(SalaryContext context)    
        {
            this.context = context;

            Employees = new EmployeeRepository(context);
            Workshops = new WorkshopRepository(context);
            Cities = new CityRepository(context);
            Workgroups = new WorkgroupRepository(context);
            FinancialYears = new FincancialYearRepository(context);
        }

        public IEmployeeRepository Employees { get; private set; }
        public IWorkshopRepository Workshops { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IWorkgroupRepository Workgroups { get; private set; }
        public IFincancialYearRepository FinancialYears { get; private set; }

        IEmployeeRepository IUnitOfWork.Employees => throw new NotImplementedException();

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
