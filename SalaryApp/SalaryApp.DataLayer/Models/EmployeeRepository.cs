using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
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
