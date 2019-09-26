namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkshopForeignKeyWorkplaceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workplaces", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Workplaces", new[] { "Workshop_Id" });
            RenameColumn(table: "dbo.Workplaces", name: "Workshop_Id", newName: "WorkshopId");
            AlterColumn("dbo.Workplaces", "WorkshopId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workplaces", "WorkshopId");
            AddForeignKey("dbo.Workplaces", "WorkshopId", "dbo.Workshops", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workplaces", "WorkshopId", "dbo.Workshops");
            DropIndex("dbo.Workplaces", new[] { "WorkshopId" });
            AlterColumn("dbo.Workplaces", "WorkshopId", c => c.Int());
            RenameColumn(table: "dbo.Workplaces", name: "WorkshopId", newName: "Workshop_Id");
            CreateIndex("dbo.Workplaces", "Workshop_Id");
            AddForeignKey("dbo.Workplaces", "Workshop_Id", "dbo.Workshops", "Id");
        }
    }
}
