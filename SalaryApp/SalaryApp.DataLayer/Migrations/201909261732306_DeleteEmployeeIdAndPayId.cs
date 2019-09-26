namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteEmployeeIdAndPayId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalaryPayDetails", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SalaryPayDetails", "PayId", "dbo.Pays");
            DropIndex("dbo.SalaryPayDetails", new[] { "PayId" });
            DropIndex("dbo.SalaryPayDetails", new[] { "EmployeeId" });
           
        }
        
        public override void Down()
        {
            
            CreateIndex("dbo.SalaryPayDetails", "EmployeeId");
            CreateIndex("dbo.SalaryPayDetails", "PayId");
            AddForeignKey("dbo.SalaryPayDetails", "PayId", "dbo.Pays", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SalaryPayDetails", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
