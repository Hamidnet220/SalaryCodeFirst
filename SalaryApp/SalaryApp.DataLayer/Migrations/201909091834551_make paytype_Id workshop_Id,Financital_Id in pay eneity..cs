namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makepaytype_Idworkshop_IdFinancital_Idinpayeneity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pays", "FinancialYear_Id", "dbo.FincancialYears");
            DropForeignKey("dbo.Pays", "PayType_Id1", "dbo.PayTypes");
            DropForeignKey("dbo.Pays", "Workshop_Id1", "dbo.Workshops");
            DropIndex("dbo.Pays", new[] { "FinancialYear_Id" });
            DropIndex("dbo.Pays", new[] { "PayType_Id1" });
            DropIndex("dbo.Pays", new[] { "Workshop_Id1" });
            AlterColumn("dbo.Pays", "FinancialYear_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Pays", "PayType_Id1");
            DropColumn("dbo.Pays", "Workshop_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pays", "Workshop_Id1", c => c.Int());
            AddColumn("dbo.Pays", "PayType_Id1", c => c.Int());
            AlterColumn("dbo.Pays", "FinancialYear_Id", c => c.Int());
            CreateIndex("dbo.Pays", "Workshop_Id1");
            CreateIndex("dbo.Pays", "PayType_Id1");
            CreateIndex("dbo.Pays", "FinancialYear_Id");
            AddForeignKey("dbo.Pays", "Workshop_Id1", "dbo.Workshops", "Id");
            AddForeignKey("dbo.Pays", "PayType_Id1", "dbo.PayTypes", "Id");
            AddForeignKey("dbo.Pays", "FinancialYear_Id", "dbo.FincancialYears", "Id");
        }
    }
}
