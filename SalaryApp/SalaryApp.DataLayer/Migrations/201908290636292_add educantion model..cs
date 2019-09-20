using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addeducantionmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Educations",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Title = c.String(),
                        Desc = c.String()
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Employees", "InsuranceId", c => c.String());
            AddColumn("dbo.Employees", "BankAccount", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Employees", "BankAccount");
            DropColumn("dbo.Employees", "InsuranceId");
            DropTable("dbo.Educations");
        }
    }
}