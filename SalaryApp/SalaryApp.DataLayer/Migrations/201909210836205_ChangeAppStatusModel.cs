namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAppStatusModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActiveUserId = c.Int(nullable: false),
                        ActiveWorkShopId = c.Int(nullable: false),
                        ActiceFinancialYearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinancialYears", t => t.ActiceFinancialYearId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ActiveUserId, cascadeDelete: true)
                .ForeignKey("dbo.Workshops", t => t.ActiveWorkShopId, cascadeDelete: true)
                .Index(t => t.ActiveUserId)
                .Index(t => t.ActiveWorkShopId)
                .Index(t => t.ActiceFinancialYearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppStatus", "ActiveWorkShopId", "dbo.Workshops");
            DropForeignKey("dbo.AppStatus", "ActiveUserId", "dbo.Users");
            DropForeignKey("dbo.AppStatus", "ActiceFinancialYearId", "dbo.FinancialYears");
            DropIndex("dbo.AppStatus", new[] { "ActiceFinancialYearId" });
            DropIndex("dbo.AppStatus", new[] { "ActiveWorkShopId" });
            DropIndex("dbo.AppStatus", new[] { "ActiveUserId" });
            DropTable("dbo.AppStatus");
        }
    }
}
