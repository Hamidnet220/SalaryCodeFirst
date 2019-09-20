using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addemployeetosalarydetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalaryPayDetails", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.SalaryPayDetails", new[] {"Employee_Id"});
            AlterColumn("dbo.SalaryPayDetails", "Employee_Id", c => c.Int(false));
            CreateIndex("dbo.SalaryPayDetails", "Employee_Id");
            AddForeignKey("dbo.SalaryPayDetails", "Employee_Id", "dbo.Employees", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.SalaryPayDetails", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.SalaryPayDetails", new[] {"Employee_Id"});
            AlterColumn("dbo.SalaryPayDetails", "Employee_Id", c => c.Int());
            CreateIndex("dbo.SalaryPayDetails", "Employee_Id");
            AddForeignKey("dbo.SalaryPayDetails", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}