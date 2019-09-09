using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class PayTypeRepository : Repository<PayType>, IPayTypeRepository
    {
        public PayTypeRepository(DbContext context) : base(context)
        {

        }

        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}
