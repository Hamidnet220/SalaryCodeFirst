using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Persistence
{
    public class SalaryContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Workshop> Workshop { get;set; }

        public DbSet<City> City { get; set; }

        public DbSet<Workgroup> Workgroup { get; set; }

        public DbSet<FincancialYear> FinancialYears { get; set; }

        public DbSet<Workplace> Workplaces { get; set; }

        public DbSet<Pay> Pays { get; set; }

        public DbSet<SalaryPayDetails> SalaryPayDetails { get; set; }

        public DbSet<AnnualPayDetails> AnnualPayDetails { get; set; }


        public SalaryContext():base("name=DefaultConnection")
        {
              
        }
    }
}
