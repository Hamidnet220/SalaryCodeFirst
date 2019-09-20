using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class makeuniqueyearinfinancailmodel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FincancialYears", "Year", true);
        }

        public override void Down()
        {
            DropIndex("dbo.FincancialYears", new[] {"Year"});
        }
    }
}