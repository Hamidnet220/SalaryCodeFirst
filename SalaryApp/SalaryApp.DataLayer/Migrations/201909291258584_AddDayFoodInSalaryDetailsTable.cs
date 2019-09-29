namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayFoodInSalaryDetailsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalaryPayDetails", "DaysFood", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalaryPayDetails", "DaysFood");
        }
    }
}
