using System;
using SalaryApp.DataLayer.Core.Repositories;

namespace SalaryApp.DataLayer.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        int Complete();
    }
}