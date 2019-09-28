namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSalaryDetailsAndAnnualDetailsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnnualPayDetails", "Employee_Id", "dbo.People");
            DropForeignKey("dbo.AnnualPayDetails", "Pay_Id", "dbo.Pays");
            DropIndex("dbo.AnnualPayDetails", new[] { "Employee_Id" });
            DropIndex("dbo.AnnualPayDetails", new[] { "Pay_Id" });
            RenameColumn(table: "dbo.AnnualPayDetails", name: "Employee_Id", newName: "EmployeeId");
            RenameColumn(table: "dbo.AnnualPayDetails", name: "Pay_Id", newName: "PayId");
            AddColumn("dbo.AnnualPayDetails", "DaysOfWork", c => c.Int(nullable: false));
            AddColumn("dbo.SalaryPayDetails", "IsTaxExempt", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AnnualPayDetails", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.AnnualPayDetails", "PayId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalaryPayDetails", "DaysOfWork", c => c.Int(nullable: false));
            CreateIndex("dbo.AnnualPayDetails", "PayId");
            CreateIndex("dbo.AnnualPayDetails", "EmployeeId");
            AddForeignKey("dbo.AnnualPayDetails", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AnnualPayDetails", "PayId", "dbo.Pays", "Id", cascadeDelete: false);
            DropColumn("dbo.AnnualPayDetails", "TotalDaysOfWork");
            DropColumn("dbo.SalaryPayDetails", "TaxExempt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalaryPayDetails", "TaxExempt", c => c.Boolean(nullable: false));
            AddColumn("dbo.AnnualPayDetails", "TotalDaysOfWork", c => c.Int(nullable: false));
            DropForeignKey("dbo.AnnualPayDetails", "PayId", "dbo.Pays");
            DropForeignKey("dbo.AnnualPayDetails", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.AnnualPayDetails", new[] { "EmployeeId" });
            DropIndex("dbo.AnnualPayDetails", new[] { "PayId" });
            AlterColumn("dbo.SalaryPayDetails", "DaysOfWork", c => c.Byte(nullable: false));
            AlterColumn("dbo.AnnualPayDetails", "PayId", c => c.Int());
            AlterColumn("dbo.AnnualPayDetails", "EmployeeId", c => c.Int());
            DropColumn("dbo.SalaryPayDetails", "IsTaxExempt");
            DropColumn("dbo.AnnualPayDetails", "DaysOfWork");
            RenameColumn(table: "dbo.AnnualPayDetails", name: "PayId", newName: "Pay_Id");
            RenameColumn(table: "dbo.AnnualPayDetails", name: "EmployeeId", newName: "Employee_Id");
            CreateIndex("dbo.AnnualPayDetails", "Pay_Id");
            CreateIndex("dbo.AnnualPayDetails", "Employee_Id");
            AddForeignKey("dbo.AnnualPayDetails", "Pay_Id", "dbo.Pays", "Id");
            AddForeignKey("dbo.AnnualPayDetails", "Employee_Id", "dbo.People", "Id");
        }
    }
}
