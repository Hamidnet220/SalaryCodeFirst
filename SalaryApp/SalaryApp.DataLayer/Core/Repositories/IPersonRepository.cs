﻿using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Repositories
{
    public interface IPersonRepository:IRepository<Person>
    {
        IEnumerable<Person> GetByAge(int value);
        IEnumerable<Person> GetByNationalCode(string NCode);
    }
}
