using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
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
        }

        public IEmployeeRepository Employees { get; private set; }
        public IWorkshopRepository Workshops { get; private set; }
        public ICityRepository Cities { get; private set; }


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
