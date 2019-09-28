namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPayDescriptionInPaytypTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PayTypes", "PayDiscription", c => c.Int(nullable: false));
            DropColumn("dbo.PayTypes", "PyPayDiscription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PayTypes", "PyPayDiscription", c => c.Int(nullable: false));
            DropColumn("dbo.PayTypes", "PayDiscription");
        }
    }
}
