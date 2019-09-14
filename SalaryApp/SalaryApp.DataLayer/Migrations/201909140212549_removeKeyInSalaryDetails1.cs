namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeKeyInSalaryDetails1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SalaryPayDetails");
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SalaryPayDetails", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SalaryPayDetails");
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SalaryPayDetails", new[] { "Pay_Id", "Employee_Id" });
        }
    }
}
