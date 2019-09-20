using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class IdentityIdInsalaryPayDetials : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(false, true));
        }

        public override void Down()
        {
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(false));
        }
    }
}