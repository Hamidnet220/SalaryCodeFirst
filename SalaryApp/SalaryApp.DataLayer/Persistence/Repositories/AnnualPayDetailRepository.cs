using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;
using System.Data.Entity;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class AnnualPayDetailRepository : Repository<AnnualPayDetails>,IAnnualPayDetailRepository
    {
        public AnnualPayDetailRepository(DbContext context) : base(context)
        {
        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}
