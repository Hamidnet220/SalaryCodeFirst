namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAppstatusTable : DbMigration
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
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppStatus");
        }
    }
}
