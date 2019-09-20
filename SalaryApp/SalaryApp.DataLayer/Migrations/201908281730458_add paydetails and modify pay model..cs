using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addpaydetailsandmodifypaymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.SalaryPayDetails",
                    c => new
                    {
                        Id = c.Int(false, true),
                        DailyRate = c.Decimal(false, 18, 2),
                        DaysOfWork = c.Byte(false),
                        ChildrenCount = c.Byte(false),
                        WorkInHoliday = c.Byte(false),
                        WorkInFriday = c.Byte(false),
                        LeaveDays = c.Byte(false),
                        MissionDays = c.Byte(false),
                        WorkOvertimeHr = c.Byte(false),
                        WorkAsStandbyDays = c.Byte(false),
                        AbsentDays = c.Byte(false),
                        MonthlyWage = c.Decimal(false, 18, 2),
                        Bon = c.Decimal(false, 18, 2),
                        Maskan = c.Decimal(false, 18, 2),
                        Karobar = c.Decimal(false, 18, 2),
                        ChildrenBenefit = c.Decimal(false, 18, 2),
                        ShifStatus = c.Boolean(false),
                        WorkInHolidayAmount = c.Decimal(false, 18, 2),
                        WrokInFridayAmoutn = c.Decimal(false, 18, 2),
                        WorkOvertimeAmount = c.Decimal(false, 18, 2),
                        WorkAsStandbyAmount = c.Decimal(false, 18, 2),
                        BadConditionRatio = c.Single(false),
                        BadConditionAmount = c.Decimal(false, 18, 2),
                        CommuteBenefiRatio = c.Single(false),
                        CommuteBenefit = c.Decimal(false, 18, 2),
                        HygieneAmount = c.Decimal(false, 18, 2),
                        FoodBenefit = c.Decimal(false, 18, 2),
                        InstructionBenefit = c.Decimal(false, 18, 2),
                        BackpayAmount = c.Decimal(false, 18, 2),
                        BackpayExempt = c.Decimal(false, 18, 2),
                        GrossAmount = c.Decimal(false, 18, 2),
                        InsuranceExempt = c.Boolean(false),
                        InsuranceIncluded = c.Decimal(false, 18, 2),
                        EmployeeIncurance = c.Decimal(false, 18, 2),
                        EmployeerIncurance = c.Decimal(false, 18, 2),
                        TaxExempt = c.Boolean(false),
                        TaxIncluded = c.Decimal(false, 18, 2),
                        TaxAmount = c.Decimal(false, 18, 2),
                        PayInAdvance = c.Decimal(false, 18, 2),
                        Loan = c.Decimal(false, 18, 2),
                        InPartPayment = c.Decimal(false, 18, 2),
                        OtherDeduction = c.Decimal(false, 18, 2),
                        OtherDeduction1 = c.Decimal(false, 18, 2),
                        NetAmount = c.Decimal(false, 18, 2),
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

            AddColumn("dbo.Pays", "MonthId", c => c.Int(false));
        }

        public override void Down()
        {
            DropForeignKey("dbo.SalaryPayDetails", "WorkGroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.SalaryPayDetails", "Pay_Id", "dbo.Pays");
            DropForeignKey("dbo.SalaryPayDetails", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.SalaryPayDetails", new[] {"WorkGroup_Id"});
            DropIndex("dbo.SalaryPayDetails", new[] {"Pay_Id"});
            DropIndex("dbo.SalaryPayDetails", new[] {"Employee_Id"});
            DropColumn("dbo.Pays", "MonthId");
            DropTable("dbo.SalaryPayDetails");
        }
    }
}