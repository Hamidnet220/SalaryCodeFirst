using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DbContext context) : base(context)
        {
        }
    }
}
