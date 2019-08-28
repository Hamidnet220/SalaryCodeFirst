namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAnnualPaydetailmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnnualPayDetails", "TotalDaysOfWork", c => c.Int(nullable: false));
            AlterColumn("dbo.AnnualPayDetails", "TotalLeaveDays", c => c.Int(nullable: false));
            AlterColumn("dbo.AnnualPayDetails", "TotalAbsentDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AnnualPayDetails", "TotalAbsentDays", c => c.Byte(nullable: false));
            AlterColumn("dbo.AnnualPayDetails", "TotalLeaveDays", c => c.Byte(nullable: false));
            AlterColumn("dbo.AnnualPayDetails", "TotalDaysOfWork", c => c.Byte(nullable: false));
        }
    }
}
