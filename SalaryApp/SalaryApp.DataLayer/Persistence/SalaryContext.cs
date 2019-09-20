using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.DataLayer.Persistence
{
    public class SalaryContext : DbContext
    {
        public DbSet AppStatus;

        public SalaryContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Workshop> Workshops { get; set; }

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

        public DbSet<User> Users { get; set; }

        public DbSet<Logsheet> Logsheets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalaryPayDetails>()
                .HasKey(t => new {t.PayId, t.EmployeeId});


            modelBuilder.Entity<SalaryPayDetails>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Logsheet>()
                .HasKey(t => new {t.PayId, t.EmployeeId})
                .Property(t => t.DayStatus).HasMaxLength(61);


            base.OnModelCreating(modelBuilder);
        }
    }
}