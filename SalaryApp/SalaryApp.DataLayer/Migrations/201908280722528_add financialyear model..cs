using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addfinancialyearmodel : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workshops", t => t.Workshop_Id)
                .Index(t => t.Workshop_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.FincancialYears", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.FincancialYears", new[] {"Workshop_Id"});
            DropTable("dbo.FincancialYears");
        }
    }
}