using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public class addworkshopmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Workshops",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Title = c.String(),
                        Address = c.String(),
                        Tel = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Workshops");
        }
    }
}