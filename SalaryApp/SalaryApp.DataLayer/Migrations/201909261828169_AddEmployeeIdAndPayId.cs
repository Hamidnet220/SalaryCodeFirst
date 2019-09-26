namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeIdAndPayId : DbMigration
    {
        public override void Up()
        {
            AddPrimaryKey("dbo.SalaryPayDetails", new[] { "PayId", "EmployeeId" });
            CreateIndex("dbo.SalaryPayDetails", "PayId");
            CreateIndex("dbo.SalaryPayDetails", "EmployeeId");
            AddForeignKey("dbo.SalaryPayDetails", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.SalaryPayDetails", "PayId", "dbo.Pays", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryPayDetails", "PayId", "dbo.Pays");
            DropForeignKey("dbo.SalaryPayDetails", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.SalaryPayDetails", new[] { "EmployeeId" });
            DropIndex("dbo.SalaryPayDetails", new[] { "PayId" });
            DropPrimaryKey("dbo.SalaryPayDetails");
        }
    }
}
