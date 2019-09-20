using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class PaystatusEnum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pays", "Status");
        }

        public override void Down()
        {
            AddColumn("dbo.Pays", "Status", c => c.Byte(false));
        }
    }
}