using System.Data.Entity;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DbContext context) : base(context)
        {
        }
    }
}