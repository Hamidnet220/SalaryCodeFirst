using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class modifyAnnualPaydetailmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnnualPayDetails", "TotalDaysOfWork", c => c.Int(false));
            AlterColumn("dbo.AnnualPayDetails", "TotalLeaveDays", c => c.Int(false));
            AlterColumn("dbo.AnnualPayDetails", "TotalAbsentDays", c => c.Int(false));
        }

        public override void Down()
        {
            AlterColumn("dbo.AnnualPayDetails", "TotalAbsentDays", c => c.Byte(false));
            AlterColumn("dbo.AnnualPayDetails", "TotalLeaveDays", c => c.Byte(false));
            AlterColumn("dbo.AnnualPayDetails", "TotalDaysOfWork", c => c.Byte(false));
        }
    }
}