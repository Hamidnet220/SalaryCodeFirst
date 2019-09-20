using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddDaysToLogsheetTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logsheets", "Pay_Id", "dbo.Pays");
            AddForeignKey("dbo.Logsheets", "Pay_Id", "dbo.Pays", "Id");
            DropColumn("dbo.Logsheets", "Days");
        }

        public override void Down()
        {
            AddColumn("dbo.Logsheets", "Days", c => c.Binary());
            DropForeignKey("dbo.Logsheets", "Pay_Id", "dbo.Pays");
            AddForeignKey("dbo.Logsheets", "Pay_Id", "dbo.Pays", "Id", true);
        }
    }
}