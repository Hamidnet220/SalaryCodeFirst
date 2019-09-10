namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvirutalworkshopinPaymodle : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Pays", "Workshop_Id");
            AddForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Pays", new[] { "Workshop_Id" });
        }
    }
}
