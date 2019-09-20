using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class makeworkshop_Idinfinancialentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FincancialYears", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.FincancialYears", new[] {"Year"});
            DropIndex("dbo.FincancialYears", new[] {"Workshop_Id"});
            CreateTable(
                    "dbo.FinancialYears",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Year = c.Int(false),
                        Workshop_Id = c.Int(false),
                        IsDeleted = c.Boolean()
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Year, unique: true);

            DropTable("dbo.FincancialYears");
        }

        public override void Down()
        {
            CreateTable(
                    "dbo.FincancialYears",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Year = c.Int(false),
                        IsDeleted = c.Boolean(),
                        Workshop_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id);

            DropIndex("dbo.FinancialYears", new[] {"Year"});
            DropTable("dbo.FinancialYears");
            CreateIndex("dbo.FincancialYears", "Workshop_Id");
            CreateIndex("dbo.FincancialYears", "Year", true);
            AddForeignKey("dbo.FincancialYears", "Workshop_Id", "dbo.Workshops", "Id");
        }
    }
}