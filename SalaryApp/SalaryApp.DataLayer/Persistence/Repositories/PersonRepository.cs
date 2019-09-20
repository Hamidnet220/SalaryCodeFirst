using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(SalaryContext context) : base(context)
        {
        }


        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}