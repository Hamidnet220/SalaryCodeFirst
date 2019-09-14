using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(SalaryContext context):base(context)
        {

        }
        

        public IEnumerable<Person> GetByNationalCode(string NCode)
        {
            throw new NotImplementedException();
        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}
