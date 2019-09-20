using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addstatusandisdeletedfieldtopaytable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pays", "Status", c => c.Byte(false, defaultValue: 1));
            AddColumn("dbo.Pays", "IsDeleted", c => c.Boolean(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Pays", "IsDeleted");
            DropColumn("dbo.Pays", "Status");
        }
    }
}