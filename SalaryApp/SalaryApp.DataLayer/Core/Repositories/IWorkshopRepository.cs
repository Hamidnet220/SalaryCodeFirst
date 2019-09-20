using System.Collections.Generic;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.DataLayer.Core.Repositories
{
    public interface IWorkshopRepository : IRepository<Workshop>
    {
        IEnumerable<Workshop> GetByTitle(string value);
    }
}