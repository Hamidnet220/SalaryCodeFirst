using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addAnnualPaydetailmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.AnnualPayDetails",
                    c => new
                    {
                        Id = c.Int(false, true),
                        DailyRate = c.Decimal(false, 18, 2),
                        TotalDaysOfWork = c.Byte(false),
                        TotalLeaveDays = c.Byte(false),
                        TotalAbsentDays = c.Byte(false),
                        EadiAmount = c.Decimal(false, 18, 2),
                        SanavatAmount = c.Decimal(false, 18, 2),
                        LeaveAmount = c.Decimal(false, 18, 2),
                        BackpayAmount = c.Decimal(false, 18, 2),
                        BackpayExempt = c.Decimal(false, 18, 2),
                        GrossAmount = c.Decimal(false, 18, 2),
                        IsInsuranceExempt = c.Boolean(false),
                        InsuranceIncluded = c.Decimal(false, 18, 2),
                        EmployeeIncurance = c.Decimal(false, 18, 2),
                        EmployeerIncurance = c.Decimal(false, 18, 2),
                        IsTaxExempt = c.Boolean(false),
                        TaxIncluded = c.Decimal(false, 18, 2),
                        TaxAmount = c.Decimal(false, 18, 2),
                        PayInAdvance = c.Decimal(false, 18, 2),
                        Loan = c.Decimal(false, 18, 2),
                        InPartPayment = c.Decimal(false, 18, 2),
                        OtherDeduction = c.Decimal(false, 18, 2),
                        OtherDeduction1 = c.Decimal(false, 18, 2),
                        NetAmount = c.Decimal(false, 18, 2),
                        Description = c.String(),
                        Employee_Id = c.Int(),
                        Pay_Id = c.Int(),
                        WorkGroup_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Pays", t => t.Pay_Id)
                .ForeignKey("dbo.Workgroups", t => t.WorkGroup_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Pay_Id)
                .Index(t => t.WorkGroup_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.AnnualPayDetails", "WorkGroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.AnnualPayDetails", "Pay_Id", "dbo.Pays");
            DropForeignKey("dbo.AnnualPayDetails", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.AnnualPayDetails", new[] {"WorkGroup_Id"});
            DropIndex("dbo.AnnualPayDetails", new[] {"Pay_Id"});
            DropIndex("dbo.AnnualPayDetails", new[] {"Employee_Id"});
            DropTable("dbo.AnnualPayDetails");
        }
    }
}