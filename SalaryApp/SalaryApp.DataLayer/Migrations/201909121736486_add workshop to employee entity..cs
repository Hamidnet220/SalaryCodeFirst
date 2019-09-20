using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addworkshoptoemployeeentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Workshop_Id", c => c.Int(false));
            CreateIndex("dbo.Employees", "Workshop_Id");
            AddForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Employees", new[] {"Workshop_Id"});
            DropColumn("dbo.Employees", "Workshop_Id");
        }
    }
}