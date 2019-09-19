namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveForiengKeyInSalaryDetail : DbMigration
    {
        public override void Up()
        {
            AddPrimaryKey("dbo.SalaryPayDetails", new[] { "PayId", "EmployeeId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SalaryPayDetails");
        }
    }
}
