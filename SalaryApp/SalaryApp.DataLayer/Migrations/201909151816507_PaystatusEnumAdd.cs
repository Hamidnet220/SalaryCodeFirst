namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaystatusEnumAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pays", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pays", "Status");
        }
    }
}
