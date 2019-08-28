namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpaymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        EmployeesCount = c.Int(nullable: false),
                        TotalGrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalInsuraceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalNetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinancialYear_Id = c.Int(),
                        Workshop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FincancialYears", t => t.FinancialYear_Id)
                .ForeignKey("dbo.Workshops", t => t.Workshop_Id)
                .Index(t => t.FinancialYear_Id)
                .Index(t => t.Workshop_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops");
            DropForeignKey("dbo.Pays", "FinancialYear_Id", "dbo.FincancialYears");
            DropIndex("dbo.Pays", new[] { "Workshop_Id" });
            DropIndex("dbo.Pays", new[] { "FinancialYear_Id" });
            DropTable("dbo.Pays");
        }
    }
}
