namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertByteForIntOfWorkovertimeHoureSalaryDetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalaryPayDetails", "WorkOvertimeHr", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalaryPayDetails", "WorkOvertimeHr", c => c.Byte(nullable: false));
        }
    }
}
