using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class PaystatusEnumAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pays", "Status", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Pays", "Status");
        }
    }
}