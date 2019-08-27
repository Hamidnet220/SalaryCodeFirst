namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        FatherName = c.String(),
                        IdNumber = c.String(),
                        NationalCode = c.String(),
                        Age = c.Int(nullable: false),
                        IsMarrid = c.Boolean(nullable: false),
                        NumberOfChildren = c.Byte(nullable: false),
                        Address = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
