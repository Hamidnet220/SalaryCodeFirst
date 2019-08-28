using SalaryApp.DataLayer.Core.Repositories;
using System;

namespace SalaryApp.DataLayer.Core
{
    public interface IUnitOfWork:IDisposable
    {
        IEmployeeRepository Employees { get; }
        int Complete();
    }
}
