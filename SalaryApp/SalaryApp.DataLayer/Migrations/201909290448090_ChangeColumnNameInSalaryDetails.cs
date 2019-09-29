namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNameInSalaryDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalaryPayDetails", "IsInsuranceExempt", c => c.Boolean(nullable: false));
            DropColumn("dbo.SalaryPayDetails", "InsuranceExempt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalaryPayDetails", "InsuranceExempt", c => c.Boolean(nullable: false));
            DropColumn("dbo.SalaryPayDetails", "IsInsuranceExempt");
        }
    }
}
