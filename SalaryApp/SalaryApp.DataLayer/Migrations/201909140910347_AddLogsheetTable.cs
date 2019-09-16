namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogsheetTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logsheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pay_Id = c.Int(nullable: false),
                        Days = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pays", t => t.Pay_Id, cascadeDelete: true)
                .Index(t => t.Pay_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logsheets", "Pay_Id", "dbo.Pays");
            DropIndex("dbo.Logsheets", new[] { "Pay_Id" });
            DropTable("dbo.Logsheets");
        }
    }
}
