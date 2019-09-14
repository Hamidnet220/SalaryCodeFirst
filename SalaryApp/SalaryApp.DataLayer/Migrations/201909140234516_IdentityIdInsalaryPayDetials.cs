namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityIdInsalaryPayDetials : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(nullable: false));
        }
    }
}
