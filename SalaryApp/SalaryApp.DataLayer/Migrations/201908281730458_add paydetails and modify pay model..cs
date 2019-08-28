namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpaydetailsandmodifypaymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryPayDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DailyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DaysOfWork = c.Byte(nullable: false),
                        ChildrenCount = c.Byte(nullable: false),
                        WorkInHoliday = c.Byte(nullable: false),
                        WorkInFriday = c.Byte(nullable: false),
                        LeaveDays = c.Byte(nullable: false),
                        MissionDays = c.Byte(nullable: false),
                        WorkOvertimeHr = c.Byte(nullable: false),
                        WorkAsStandbyDays = c.Byte(nullable: false),
                        AbsentDays = c.Byte(nullable: false),
                        MonthlyWage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Maskan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Karobar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChildrenBenefit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShifStatus = c.Boolean(nullable: false),
                        WorkInHolidayAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WrokInFridayAmoutn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WorkOvertimeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WorkAsStandbyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BadConditionRatio = c.Single(nullable: false),
                        BadConditionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommuteBenefiRatio = c.Single(nullable: false),
                        CommuteBenefit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HygieneAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodBenefit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InstructionBenefit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BackpayAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BackpayExempt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InsuranceExempt = c.Boolean(nullable: false),
                        InsuranceIncluded = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeIncurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeerIncurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxExempt = c.Boolean(nullable: false),
                        TaxIncluded = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayInAdvance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Loan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPartPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherDeduction1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_Id = c.Int(),
                        Pay_Id = c.Int(),
                        WorkGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Pays", t => t.Pay_Id)
                .ForeignKey("dbo.Workgroups", t => t.WorkGroup_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Pay_Id)
                .Index(t => t.WorkGroup_Id);
            
            AddColumn("dbo.Pays", "MonthId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryPayDetails", "WorkGroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.SalaryPayDetails", "Pay_Id", "dbo.Pays");
            DropForeignKey("dbo.SalaryPayDetails", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.SalaryPayDetails", new[] { "WorkGroup_Id" });
            DropIndex("dbo.SalaryPayDetails", new[] { "Pay_Id" });
            DropIndex("dbo.SalaryPayDetails", new[] { "Employee_Id" });
            DropColumn("dbo.Pays", "MonthId");
            DropTable("dbo.SalaryPayDetails");
        }
    }
}
