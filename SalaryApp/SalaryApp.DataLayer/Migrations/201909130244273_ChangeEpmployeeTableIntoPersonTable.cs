using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class ChangeEpmployeeTableIntoPersonTable : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.Employees", "People");
        }

        public override void Down()
        {
            RenameTable("dbo.People", "Employees");
        }
    }
}