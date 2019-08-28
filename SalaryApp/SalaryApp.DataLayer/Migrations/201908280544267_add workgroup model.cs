namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addworkgroupmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workgroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Maskan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChildrenBenefit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsShift = c.Boolean(),
                        ShiftRation = c.Single(nullable: false),
                        TaxExept = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Workshop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workshops", t => t.Workshop_Id)
                .Index(t => t.Workshop_Id);
            
            AlterColumn("dbo.Workshops", "Title", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workgroups", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Workgroups", new[] { "Workshop_Id" });
            AlterColumn("dbo.Workshops", "Title", c => c.String());
            DropTable("dbo.Workgroups");
        }
    }
}
