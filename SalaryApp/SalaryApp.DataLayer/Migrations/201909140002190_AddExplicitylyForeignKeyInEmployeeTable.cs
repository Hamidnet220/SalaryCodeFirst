using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddExplicitylyForeignKeyInEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops");
            DropForeignKey("dbo.Employees", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces");
            DropIndex("dbo.Employees", new[] {"Person_Id"});
            DropIndex("dbo.Employees", new[] {"Workgroup_Id"});
            DropIndex("dbo.Employees", new[] {"Workplace_Id"});
            DropIndex("dbo.Employees", new[] {"Workshop_Id"});
            AlterColumn("dbo.Employees", "Person_Id", c => c.Int(false));
            AlterColumn("dbo.Employees", "Workgroup_Id", c => c.Int(false));
            AlterColumn("dbo.Employees", "Workplace_Id", c => c.Int(false));
            CreateIndex("dbo.Employees", "Person_Id");
            CreateIndex("dbo.Employees", "Workgroup_Id");
            CreateIndex("dbo.Employees", "Workplace_Id");
            AddForeignKey("dbo.Employees", "Person_Id", "dbo.People", "Id", true);
            AddForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups", "Id", true);
            AddForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces", "Id", true);
            DropColumn("dbo.Employees", "Workshop_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Employees", "Workshop_Id", c => c.Int());
            DropForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces");
            DropForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.Employees", "Person_Id", "dbo.People");
            DropIndex("dbo.Employees", new[] {"Workplace_Id"});
            DropIndex("dbo.Employees", new[] {"Workgroup_Id"});
            DropIndex("dbo.Employees", new[] {"Person_Id"});
            AlterColumn("dbo.Employees", "Workplace_Id", c => c.Int());
            AlterColumn("dbo.Employees", "Workgroup_Id", c => c.Int());
            AlterColumn("dbo.Employees", "Person_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Workshop_Id");
            CreateIndex("dbo.Employees", "Workplace_Id");
            CreateIndex("dbo.Employees", "Workgroup_Id");
            CreateIndex("dbo.Employees", "Person_Id");
            AddForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces", "Id");
            AddForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups", "Id");
            AddForeignKey("dbo.Employees", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops", "Id");
        }
    }
}