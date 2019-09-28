namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPayDescriptionInPaytypTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PayTypes", "PyPayDiscription", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayTypes", "PyPayDiscription");
        }
    }
}
