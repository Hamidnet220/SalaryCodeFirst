using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addvirutalPaytypeinPaymodle : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Pays", "PayType_Id");
            AddForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes");
            DropIndex("dbo.Pays", new[] {"PayType_Id"});
        }
    }
}