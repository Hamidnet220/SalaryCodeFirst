namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShiftAmountInSalaryDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalaryPayDetails", "ShiftAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalaryPayDetails", "ShiftAmount");
        }
    }
}
