namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStandayAmountRateInWorkgroupTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workgroups", "StandbayAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2,defaultValue:0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workgroups", "StandbayAmount");
        }
    }
}
