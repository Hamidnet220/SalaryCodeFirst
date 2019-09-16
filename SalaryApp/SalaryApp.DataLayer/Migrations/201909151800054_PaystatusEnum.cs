namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaystatusEnum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pays", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pays", "Status", c => c.Byte(nullable: false));
        }
    }
}
