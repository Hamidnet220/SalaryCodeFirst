namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeworkshop_Idinfinancialentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FincancialYears", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.FincancialYears", new[] { "Year" });
            DropIndex("dbo.FincancialYears", new[] { "Workshop_Id" });
            CreateTable(
                "dbo.FinancialYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Workshop_Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Year, unique: true);
            
            DropTable("dbo.FincancialYears");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FincancialYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        Workshop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.FinancialYears", new[] { "Year" });
            DropTable("dbo.FinancialYears");
            CreateIndex("dbo.FincancialYears", "Workshop_Id");
            CreateIndex("dbo.FincancialYears", "Year", unique: true);
            AddForeignKey("dbo.FincancialYears", "Workshop_Id", "dbo.Workshops", "Id");
        }
    }
}
