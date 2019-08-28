using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public class WorkshopRepository : Repository<Workshop>,IWorkshopRepository
    {
        public WorkshopRepository(DbContext context) : base(context)
        {
        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }

        public IEnumerable<Workshop> GetByTitle(string value)
        {
            throw new NotImplementedException();
        }
    }
}
