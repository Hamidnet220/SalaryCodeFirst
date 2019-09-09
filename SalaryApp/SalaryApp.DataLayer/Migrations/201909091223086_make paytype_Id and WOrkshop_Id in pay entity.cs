namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makepaytype_IdandWOrkshop_Idinpayentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes");
            DropForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Pays", new[] { "PayType_Id" });
            DropIndex("dbo.Pays", new[] { "Workshop_Id" });
            AddColumn("dbo.Pays", "PayType_Id1", c => c.Int());
            AddColumn("dbo.Pays", "Workshop_Id1", c => c.Int());
            AlterColumn("dbo.Pays", "PayType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Pays", "Workshop_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Pays", "PayType_Id1");
            CreateIndex("dbo.Pays", "Workshop_Id1");
            AddForeignKey("dbo.Pays", "PayType_Id1", "dbo.PayTypes", "Id");
            AddForeignKey("dbo.Pays", "Workshop_Id1", "dbo.Workshops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "Workshop_Id1", "dbo.Workshops");
            DropForeignKey("dbo.Pays", "PayType_Id1", "dbo.PayTypes");
            DropIndex("dbo.Pays", new[] { "Workshop_Id1" });
            DropIndex("dbo.Pays", new[] { "PayType_Id1" });
            AlterColumn("dbo.Pays", "Workshop_Id", c => c.Int());
            AlterColumn("dbo.Pays", "PayType_Id", c => c.Int());
            DropColumn("dbo.Pays", "Workshop_Id1");
            DropColumn("dbo.Pays", "PayType_Id1");
            CreateIndex("dbo.Pays", "Workshop_Id");
            CreateIndex("dbo.Pays", "PayType_Id");
            AddForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops", "Id");
            AddForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes", "Id");
        }
    }
}
