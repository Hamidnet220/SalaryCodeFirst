using System.Data.Entity;
using SalaryApp.DataLayer.Core.Repositories;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class LogsheetRepository : Repository<Logsheet>, ILogsheetRepository
    {
        public LogsheetRepository(DbContext context) : base(context)
        {
        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}
