using System.Data.Entity;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;
using ISalaryPayDetails = SalaryApp.DataLayer.Core.Repositories.ISalaryPayDetails;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class SalaryPayDetailsRepository : Repository<SalaryPayDetails>, ISalaryPayDetails
    {
        public SalaryPayDetailsRepository(DbContext context) : base(context)
        {
        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}