using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addcitymodel : DbMigration
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


            CreateTable(
                    "dbo.Cities",
                    c => new
                    {
                        Id = c.Int(false, true),
                        CityName = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Cities");
            DropTable("dbo.Workshops");
        }
    }
}