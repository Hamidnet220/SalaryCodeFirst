using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class addworkgroupmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Workgroups",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Title = c.String(),
                        Rate = c.Decimal(false, 18, 2),
                        Bon = c.Decimal(false, 18, 2),
                        Maskan = c.Decimal(false, 18, 2),
                        ChildrenBenefit = c.Decimal(false, 18, 2),
                        IsShift = c.Boolean(),
                        ShiftRation = c.Single(false),
                        TaxExept = c.Decimal(false, 18, 2),
                        Description = c.String(),
                        Workshop_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workshops", t => t.Workshop_Id)
                .Index(t => t.Workshop_Id);

            AlterColumn("dbo.Workshops", "Title", c => c.String(false, 150));
        }

        public override void Down()
        {
            DropForeignKey("dbo.Workgroups", "Workshop_Id", "dbo.Workshops");
            DropIndex("dbo.Workgroups", new[] {"Workshop_Id"});
            AlterColumn("dbo.Workshops", "Title", c => c.String());
            DropTable("dbo.Workgroups");
        }
    }
}