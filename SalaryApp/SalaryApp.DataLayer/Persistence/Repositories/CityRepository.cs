using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DbContext context) : base(context)
        {
        }
    }
}
