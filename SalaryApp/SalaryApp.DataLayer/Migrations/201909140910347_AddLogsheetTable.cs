using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddLogsheetTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Logsheets",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Pay_Id = c.Int(false),
                        Days = c.Binary()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pays", t => t.Pay_Id, true)
                .Index(t => t.Pay_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Logsheets", "Pay_Id", "dbo.Pays");
            DropIndex("dbo.Logsheets", new[] {"Pay_Id"});
            DropTable("dbo.Logsheets");
        }
    }
}