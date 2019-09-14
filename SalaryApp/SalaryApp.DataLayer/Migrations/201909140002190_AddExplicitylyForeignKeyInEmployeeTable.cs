namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExplicitylyForeignKeyInEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces");
            DropForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Employees", new[] { "Person_Id" });
            DropIndex("dbo.Employees", new[] { "Workgroup_Id" });
            DropIndex("dbo.Employees", new[] { "Workplace_Id" });
            DropIndex("dbo.Employees", new[] { "Workshop_Id" });
            AlterColumn("dbo.Employees", "Person_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Workgroup_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Workplace_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Workshop_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Person_Id");
            CreateIndex("dbo.Employees", "Workshop_Id");
            CreateIndex("dbo.Employees", "Workgroup_Id");
            CreateIndex("dbo.Employees", "Workplace_Id");
            AddForeignKey("dbo.Employees", "Person_Id", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops");
            DropForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces");
            DropForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.Employees", "Person_Id", "dbo.People");
            DropIndex("dbo.Employees", new[] { "Workplace_Id" });
            DropIndex("dbo.Employees", new[] { "Workgroup_Id" });
            DropIndex("dbo.Employees", new[] { "Workshop_Id" });
            DropIndex("dbo.Employees", new[] { "Person_Id" });
            AlterColumn("dbo.Employees", "Workshop_Id", c => c.Int());
            AlterColumn("dbo.Employees", "Workplace_Id", c => c.Int());
            AlterColumn("dbo.Employees", "Workgroup_Id", c => c.Int());
            AlterColumn("dbo.Employees", "Person_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Workshop_Id");
            CreateIndex("dbo.Employees", "Workplace_Id");
            CreateIndex("dbo.Employees", "Workgroup_Id");
            CreateIndex("dbo.Employees", "Person_Id");
            AddForeignKey("dbo.Employees", "Workshop_Id", "dbo.Workshops", "Id");
            AddForeignKey("dbo.Employees", "Workplace_Id", "dbo.Workplaces", "Id");
            AddForeignKey("dbo.Employees", "Workgroup_Id", "dbo.Workgroups", "Id");
            AddForeignKey("dbo.Employees", "Person_Id", "dbo.People", "Id");
        }
    }
}
