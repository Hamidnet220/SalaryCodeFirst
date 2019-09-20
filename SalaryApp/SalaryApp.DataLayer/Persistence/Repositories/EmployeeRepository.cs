using System;
using System.Collections.Generic;
using System.Data.Entity;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {
        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }

        public IEnumerable<Employee> GetByNationalCode(string NCode)
        {
            throw new NotImplementedException();
        }
    }
}