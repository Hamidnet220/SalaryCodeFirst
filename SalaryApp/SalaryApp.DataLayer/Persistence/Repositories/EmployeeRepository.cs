using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SalaryContext context):base(context)
        {

        }
        public IEnumerable<Employee> GetByAge(int value)
        {
            return SalaryContext.Employee.Where(emp => emp.Age == value);
        }

        public IEnumerable<Employee> GetByNationalCode(string NCode)
        {
            throw new NotImplementedException();
        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}
