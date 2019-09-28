namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBonusPayDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BonusPayDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        DailyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DaysOfWork = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Pays", t => t.PayId, cascadeDelete: false)
                .Index(t => t.PayId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BonusPayDetails", "PayId", "dbo.Pays");
            DropForeignKey("dbo.BonusPayDetails", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.BonusPayDetails", new[] { "EmployeeId" });
            DropIndex("dbo.BonusPayDetails", new[] { "PayId" });
            DropTable("dbo.BonusPayDetails");
        }
    }
}
