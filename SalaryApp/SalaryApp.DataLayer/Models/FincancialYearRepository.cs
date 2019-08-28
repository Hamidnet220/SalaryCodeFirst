using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public class FincancialYearRepository : Repository<FincancialYear>,IFincancialYearRepository
    {
        public FincancialYearRepository(DbContext context) : base(context)
        {

        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}
