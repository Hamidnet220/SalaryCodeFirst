namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeducantionmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "InsuranceId", c => c.String());
            AddColumn("dbo.Employees", "BankAccount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "BankAccount");
            DropColumn("dbo.Employees", "InsuranceId");
            DropTable("dbo.Educations");
        }
    }
}
