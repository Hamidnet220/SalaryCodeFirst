namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpaytypeentityandaddittopayentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PayTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayTitle = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pays", "PayType_Id", c => c.Int());
            CreateIndex("dbo.Pays", "PayType_Id");
            AddForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes");
            DropIndex("dbo.Pays", new[] { "PayType_Id" });
            DropColumn("dbo.Pays", "PayType_Id");
            DropTable("dbo.PayTypes");
        }
    }
}
