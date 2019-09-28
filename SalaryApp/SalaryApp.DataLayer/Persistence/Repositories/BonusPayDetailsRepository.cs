using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class BonusPayDetailsRepository:Repository<BonusPayDetails>,IBonusPayDetails
    {
        public BonusPayDetailsRepository(DbContext context) : base(context)
        {
        }
        public SalaryContext SalaryContext
        {
            get { return context as SalaryContext; }
        }
    }
}
