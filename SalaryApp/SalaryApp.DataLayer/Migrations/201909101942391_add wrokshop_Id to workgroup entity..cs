namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwrokshop_Idtoworkgroupentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workgroups", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Workgroups", new[] { "Workshop_Id" });
            AlterColumn("dbo.Workgroups", "Workshop_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Workgroups", "Workshop_Id");
            AddForeignKey("dbo.Workgroups", "Workshop_Id", "dbo.Workshops", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workgroups", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Workgroups", new[] { "Workshop_Id" });
            AlterColumn("dbo.Workgroups", "Workshop_Id", c => c.Int());
            CreateIndex("dbo.Workgroups", "Workshop_Id");
            AddForeignKey("dbo.Workgroups", "Workshop_Id", "dbo.Workshops", "Id");
        }
    }
}
