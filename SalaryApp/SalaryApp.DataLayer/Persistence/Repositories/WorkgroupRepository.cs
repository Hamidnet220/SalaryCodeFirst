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
    public class WorkgroupRepository : Repository<Workgroup>,IWorkgroupRepository
    {
        public WorkgroupRepository(DbContext context) : base(context)
        {
        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}
