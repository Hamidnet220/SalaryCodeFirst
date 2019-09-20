using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class DeleteEducation_IdFromPersonEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Education_Id", "dbo.Educations");
            DropIndex("dbo.People", new[] {"Education_Id"});
            AlterColumn("dbo.People", "Education_Id", c => c.Int(true));
            CreateIndex("dbo.People", "Education_Id");
            AddForeignKey("dbo.People", "Education_Id", "dbo.Educations", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.People", "Education_Id", "dbo.Educations");
            DropIndex("dbo.People", new[] {"Education_Id"});
            AlterColumn("dbo.People", "Education_Id", c => c.Int(false));
            CreateIndex("dbo.People", "Education_Id");
            AddForeignKey("dbo.People", "Education_Id", "dbo.Educations", "Id", true);
        }
    }
}