namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodAmountInWorkgroupTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workgroups", "FoodBenefitAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Workgroups", "IsShift", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workgroups", "IsShift", c => c.Boolean());
            DropColumn("dbo.Workgroups", "FoodBenefitAmount");
        }
    }
}
