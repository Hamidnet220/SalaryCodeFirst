using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddLogDayInLogsheetTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.SalaryPayDetails", "Employee_Id", "EmployeeId");
            RenameColumn("dbo.SalaryPayDetails", "Pay_Id", "PayId");
            RenameIndex("dbo.SalaryPayDetails", "IX_Pay_Id", "IX_PayId");
            RenameIndex("dbo.SalaryPayDetails", "IX_Employee_Id", "IX_EmployeeId");
            CreateTable(
                    "dbo.Logsheets",
                    c => new
                    {
                        PayId = c.Int(false),
                        EmployeeId = c.Int(false),
                        Id = c.Int(false),
                        DayStatus = c.String(maxLength: 61)
                    })
                .PrimaryKey(t => new {t.PayId, t.EmployeeId})
                .ForeignKey("dbo.Employees", t => t.EmployeeId, false)
                .ForeignKey("dbo.Pays", t => t.PayId, false)
                .Index(t => t.PayId)
                .Index(t => t.EmployeeId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Logsheets", "PayId", "dbo.Pays");
            DropForeignKey("dbo.Logsheets", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Logsheets", new[] {"EmployeeId"});
            DropIndex("dbo.Logsheets", new[] {"PayId"});
            DropTable("dbo.Logsheets");
            RenameIndex("dbo.SalaryPayDetails", "IX_EmployeeId", "IX_Employee_Id");
            RenameIndex("dbo.SalaryPayDetails", "IX_PayId", "IX_Pay_Id");
            RenameColumn("dbo.SalaryPayDetails", "PayId", "Pay_Id");
            RenameColumn("dbo.SalaryPayDetails", "EmployeeId", "Employee_Id");
        }
    }
}