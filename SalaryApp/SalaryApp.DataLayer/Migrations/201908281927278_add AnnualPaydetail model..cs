namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnnualPaydetailmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnualPayDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DailyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDaysOfWork = c.Byte(nullable: false),
                        TotalLeaveDays = c.Byte(nullable: false),
                        TotalAbsentDays = c.Byte(nullable: false),
                        EadiAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SanavatAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeaveAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BackpayAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BackpayExempt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsInsuranceExempt = c.Boolean(nullable: false),
                        InsuranceIncluded = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeIncurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeerIncurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTaxExempt = c.Boolean(nullable: false),
                        TaxIncluded = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayInAdvance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Loan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPartPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherDeduction1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnnualPayDetails", "WorkGroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.AnnualPayDetails", "Pay_Id", "dbo.Pays");
            DropForeignKey("dbo.AnnualPayDetails", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.AnnualPayDetails", new[] { "WorkGroup_Id" });
            DropIndex("dbo.AnnualPayDetails", new[] { "Pay_Id" });
            DropIndex("dbo.AnnualPayDetails", new[] { "Employee_Id" });
            DropTable("dbo.AnnualPayDetails");
        }
    }
}
