using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class setkeyforappstatus : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AppStatus");
        }

        public override void Down()
        {
            CreateTable(
                    "dbo.AppStatus",
                    c => new
                    {
                        Id = c.Int(false, true),
                        ActiveUserId = c.Int(false),
                        ActiveWorkShopId = c.Int(false),
                        ActiceFinancialYearId = c.Int(false)
                    })
                .PrimaryKey(t => t.Id);
        }
    }
}