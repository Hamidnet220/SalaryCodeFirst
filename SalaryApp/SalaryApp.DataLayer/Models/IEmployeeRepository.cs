using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        IEnumerable<Employee> GetByAge(int value);
        IEnumerable<Employee> GetByNationalCode(string NCode);
    }
}
