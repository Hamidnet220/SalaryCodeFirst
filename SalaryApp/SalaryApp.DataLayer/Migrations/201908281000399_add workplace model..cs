namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addworkplacemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workplaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Workshop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workshops", t => t.Workshop_Id)
                .Index(t => t.Workshop_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workplaces", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Workplaces", new[] { "Workshop_Id" });
            DropTable("dbo.Workplaces");
        }
    }
}
