namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHyginAndChangeColumnNameWorkgroupTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workgroups", "TaxExeptAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Workgroups", "TaxRatio", c => c.Single(nullable: false));
            AddColumn("dbo.Workgroups", "HygieneAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Workgroups", "TaxExept");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workgroups", "TaxExept", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Workgroups", "HygieneAmount");
            DropColumn("dbo.Workgroups", "TaxRatio");
            DropColumn("dbo.Workgroups", "TaxExeptAmount");
        }
    }
}
