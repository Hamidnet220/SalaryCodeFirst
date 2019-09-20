using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Employees",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Person_Id = c.Int(),
                        Workgroup_Id = c.Int(true),
                        Workplace_Id = c.Int(true),
                        Workshop_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.Workgroups", t => t.Workgroup_Id)
                .ForeignKey("dbo.Workplaces", t => t.Workplace_Id)
                .ForeignKey("dbo.Workshops", t => t.Workshop_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Workgroup_Id)
                .Index(t => t.Workplace_Id)
                .Index(t => t.Workshop_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops");
            DropForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces");
            DropForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.Employees", "Person_Id", "dbo.People");
            DropIndex("dbo.Employees", new[] {"Workshop_Id"});
            DropIndex("dbo.Employees", new[] {"Workplace_Id"});
            DropIndex("dbo.Employees", new[] {"Workgroup_Id"});
            DropIndex("dbo.Employees", new[] {"Person_Id"});
            DropTable("dbo.Employees");
        }
    }
}