namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvirtualworkshopvirtualFinanactialtopaymodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pays", "Workshop_Id", c => c.Int());
            AlterColumn("dbo.Pays", "FinancialYear_Id", c => c.Int());
            CreateIndex("dbo.Pays", "FinancialYear_Id");
            CreateIndex("dbo.Pays", "Workshop_Id");
            AddForeignKey("dbo.Pays", "FinancialYear_Id", "dbo.FinancialYears", "Id");
            AddForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops");
            DropForeignKey("dbo.Pays", "FinancialYear_Id", "dbo.FinancialYears");
            DropIndex("dbo.Pays", new[] { "Workshop_Id" });
            DropIndex("dbo.Pays", new[] { "FinancialYear_Id" });
            AlterColumn("dbo.Pays", "FinancialYear_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Pays", "Workshop_Id", c => c.Int(nullable: false));
        }
    }
}
