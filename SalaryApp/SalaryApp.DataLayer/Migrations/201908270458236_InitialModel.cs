using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Employees",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        FatherName = c.String(),
                        IdNumber = c.String(),
                        NationalCode = c.String(),
                        Age = c.Int(false),
                        IsMarrid = c.Boolean(false),
                        NumberOfChildren = c.Byte(false),
                        Address = c.String(),
                        Mobile = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}