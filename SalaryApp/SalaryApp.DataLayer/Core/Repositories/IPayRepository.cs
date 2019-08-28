using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalaryApp.DataLayer.Core.Repositories
{
    public interface IPayRepository : IRepository<Pay>
    {
        
    }
}
