using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class undochangesinpaytype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pays", "FinancialYear_Id", "dbo.FinancialYears");
            DropForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes");
            DropForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Pays", new[] {"FinancialYear_Id"});
            DropIndex("dbo.Pays", new[] {"PayType_Id"});
            DropIndex("dbo.Pays", new[] {"Workshop_Id"});
            AlterColumn("dbo.Pays", "FinancialYear_Id", c => c.Int(false));
            AlterColumn("dbo.Pays", "PayType_Id", c => c.Int(false));
            AlterColumn("dbo.Pays", "Workshop_Id", c => c.Int(false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Pays", "Workshop_Id", c => c.Int());
            AlterColumn("dbo.Pays", "PayType_Id", c => c.Int());
            AlterColumn("dbo.Pays", "FinancialYear_Id", c => c.Int());
            CreateIndex("dbo.Pays", "Workshop_Id");
            CreateIndex("dbo.Pays", "PayType_Id");
            CreateIndex("dbo.Pays", "FinancialYear_Id");
            AddForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops", "Id");
            AddForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes", "Id");
            AddForeignKey("dbo.Pays", "FinancialYear_Id", "dbo.FinancialYears", "Id");
        }
    }
}