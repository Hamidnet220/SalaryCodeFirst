using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddCompositionKeyInSalaryPayDetails1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SalaryPayDetails");
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(false));
            AddPrimaryKey("dbo.SalaryPayDetails", new[] {"Pay_Id", "Employee_Id"});
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.SalaryPayDetails");
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(false, true));
            AddPrimaryKey("dbo.SalaryPayDetails", "Id");
        }
    }
}