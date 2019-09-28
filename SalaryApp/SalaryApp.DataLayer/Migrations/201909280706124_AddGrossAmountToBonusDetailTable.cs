namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGrossAmountToBonusDetailTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BonusPayDetails", "GrossAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BonusPayDetails", "GrossAmount");
        }
    }
}
