using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addpaymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Pays",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Title = c.String(),
                        EmployeesCount = c.Int(false),
                        TotalGrossAmount = c.Decimal(false, 18, 2),
                        TotalTaxAmount = c.Decimal(false, 18, 2),
                        TotalInsuraceAmount = c.Decimal(false, 18, 2),
                        TotalNetAmount = c.Decimal(false, 18, 2),
                        FinancialYear_Id = c.Int(),
                        Workshop_Id = c.Int()
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
            DropIndex("dbo.Pays", new[] {"Workshop_Id"});
            DropIndex("dbo.Pays", new[] {"FinancialYear_Id"});
            DropTable("dbo.Pays");
        }
    }
}