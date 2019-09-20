using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddPOB_POI_DOB_ColumnsToPeopleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "DOB", c => c.DateTime());
            AddColumn("dbo.People", "POB", c => c.Int(false));
            AddColumn("dbo.People", "POI", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.People", "POI");
            DropColumn("dbo.People", "POB");
            DropColumn("dbo.People", "DOB");
        }
    }
}