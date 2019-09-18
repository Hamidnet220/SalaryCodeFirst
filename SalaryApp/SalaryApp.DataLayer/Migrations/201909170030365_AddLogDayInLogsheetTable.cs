namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogDayInLogsheetTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SalaryPayDetails", name: "Employee_Id", newName: "EmployeeId");
            RenameColumn(table: "dbo.SalaryPayDetails", name: "Pay_Id", newName: "PayId");
            RenameIndex(table: "dbo.SalaryPayDetails", name: "IX_Pay_Id", newName: "IX_PayId");
            RenameIndex(table: "dbo.SalaryPayDetails", name: "IX_Employee_Id", newName: "IX_EmployeeId");
            CreateTable(
                "dbo.Logsheets",
                c => new
                    {
                        PayId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        DayStatus = c.String(maxLength: 61),
                    })
                .PrimaryKey(t => new { t.PayId, t.EmployeeId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Pays", t => t.PayId, cascadeDelete: false)
                .Index(t => t.PayId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logsheets", "PayId", "dbo.Pays");
            DropForeignKey("dbo.Logsheets", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Logsheets", new[] { "EmployeeId" });
            DropIndex("dbo.Logsheets", new[] { "PayId" });
            DropTable("dbo.Logsheets");
            RenameIndex(table: "dbo.SalaryPayDetails", name: "IX_EmployeeId", newName: "IX_Employee_Id");
            RenameIndex(table: "dbo.SalaryPayDetails", name: "IX_PayId", newName: "IX_Pay_Id");
            RenameColumn(table: "dbo.SalaryPayDetails", name: "PayId", newName: "Pay_Id");
            RenameColumn(table: "dbo.SalaryPayDetails", name: "EmployeeId", newName: "Employee_Id");
        }
    }
}
