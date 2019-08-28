namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeuniqueyearinfinancailmodel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FincancialYears", "Year", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.FincancialYears", new[] { "Year" });
        }
    }
}
