using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addeducationinemployeemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Education_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Education_Id");
            AddForeignKey("dbo.Employees", "Education_Id", "dbo.Educations", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Education_Id", "dbo.Educations");
            DropIndex("dbo.Employees", new[] {"Education_Id"});
            DropColumn("dbo.Employees", "Education_Id");
        }
    }
}