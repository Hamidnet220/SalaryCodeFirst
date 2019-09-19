namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePayId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SalaryPayDetails");
        }
        
        public override void Down()
        {
            AddPrimaryKey("dbo.SalaryPayDetails", new[] { "Pay_Id", "Employee_Id" });
        }
    }
}
