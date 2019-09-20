using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addvirutalworkshopinPaymodle : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Pays", "Workshop_Id");
            AddForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Pays", new[] {"Workshop_Id"});
        }
    }
}