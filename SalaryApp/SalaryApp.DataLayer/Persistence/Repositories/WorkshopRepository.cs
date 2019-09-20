using System;
using System.Collections.Generic;
using System.Data.Entity;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Core.Repositories;

namespace SalaryApp.DataLayer.Persistence.Repositories
{
    public class WorkshopRepository : Repository<Workshop>, IWorkshopRepository
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