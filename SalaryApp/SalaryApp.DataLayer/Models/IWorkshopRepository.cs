using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public interface IWorkshopRepository:IRepository<Workshop>
    {
        IEnumerable<Workshop> GetByTitle(string value);
    }
}
