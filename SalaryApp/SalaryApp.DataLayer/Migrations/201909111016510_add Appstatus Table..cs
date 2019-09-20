using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addAppstatusTable : DbMigration
    {
        public override void Up()
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

        public override void Down()
        {
            DropTable("dbo.AppStatus");
        }
    }
}