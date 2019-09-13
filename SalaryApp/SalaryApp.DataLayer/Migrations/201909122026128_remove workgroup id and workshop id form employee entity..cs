namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeworkgroupidandworkshopidformemployeeentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Employees", new[] { "Workshop_Id" });
            DropColumn("dbo.Employees", "Workshop_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Workshop_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Workshop_Id");
            AddForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops", "Id", cascadeDelete: true);
        }
    }
}
