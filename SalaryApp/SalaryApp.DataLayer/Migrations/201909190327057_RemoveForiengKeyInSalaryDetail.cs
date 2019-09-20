using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class RemoveForiengKeyInSalaryDetail : DbMigration
    {
        public override void Up()
        {
            AddPrimaryKey("dbo.SalaryPayDetails", new[] {"PayId", "EmployeeId"});
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.SalaryPayDetails");
        }
    }
}