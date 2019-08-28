using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public class SalaryContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Workshop> Workshop { get;set; }

        public DbSet<City> City { get; set; }

        public SalaryContext():base("name=DefaultConnection")
        {
              
        }
    }
}
