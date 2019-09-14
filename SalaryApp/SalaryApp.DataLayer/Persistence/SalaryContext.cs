using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<Person> People { get; set; }

        public DbSet<Workshop> Workshops { get;set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Workgroup> Workgroups { get; set; }

        public DbSet<FinancialYear> FinancialYears { get; set; }

        public DbSet<Workplace> Workplaces { get; set; }

        public DbSet<Pay> Pays { get; set; }

        public DbSet<SalaryPayDetails> SalaryPayDetails { get; set; }

        public DbSet<AnnualPayDetails> AnnualPayDetails { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<PayType> Paytypes { get; set; }
        
        public DbSet<Employee> Employees { get; set; }

        public DbSet AppStatus;

        public DbSet<User> Users { get; set; }

        public SalaryContext():base("name=DefaultConnection")
        {
              
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalaryPayDetails>()
           .HasKey(t => new { t.Pay_Id, t.Employee_Id });


            modelBuilder.Entity<SalaryPayDetails>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}
