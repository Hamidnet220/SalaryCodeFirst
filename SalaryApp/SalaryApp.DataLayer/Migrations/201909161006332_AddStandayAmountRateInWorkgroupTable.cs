using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddStandayAmountRateInWorkgroupTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workgroups", "StandbayAmount", c => c.Decimal(false, 18, 2, 0));
        }

        public override void Down()
        {
            DropColumn("dbo.Workgroups", "StandbayAmount");
        }
    }
}