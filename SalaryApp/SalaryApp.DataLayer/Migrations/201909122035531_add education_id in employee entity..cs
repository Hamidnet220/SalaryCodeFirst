namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeducation_idinemployeeentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Education_Id", "dbo.Educations");
            DropIndex("dbo.Employees", new[] { "Education_Id" });
            AlterColumn("dbo.Employees", "Education_Id", c => c.Int(nullable: true));
            CreateIndex("dbo.Employees", "Education_Id");
            AddForeignKey("dbo.Employees", "Education_Id", "dbo.Educations", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Education_Id", "dbo.Educations");
            DropIndex("dbo.Employees", new[] { "Education_Id" });
            AlterColumn("dbo.Employees", "Education_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Education_Id");
            AddForeignKey("dbo.Employees", "Education_Id", "dbo.Educations", "Id");
        }
    }
}
