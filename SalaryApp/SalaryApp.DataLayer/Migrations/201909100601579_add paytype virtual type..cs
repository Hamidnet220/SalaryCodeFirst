namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpaytypevirtualtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pays", "PayType_Id", c => c.Int());
            CreateIndex("dbo.Pays", "PayType_Id");
            AddForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "PayType_Id", "dbo.PayTypes");
            DropIndex("dbo.Pays", new[] { "PayType_Id" });
            AlterColumn("dbo.Pays", "PayType_Id", c => c.Int(nullable: false));
        }
    }
}
