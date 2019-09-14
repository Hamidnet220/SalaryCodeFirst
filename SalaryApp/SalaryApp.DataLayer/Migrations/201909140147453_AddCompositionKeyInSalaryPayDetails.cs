namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompositionKeyInSalaryPayDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalaryPayDetails", "Workgroup_Id", "dbo.Workgroups");
            DropIndex("dbo.SalaryPayDetails", new[] { "Workgroup_Id" });
            DropPrimaryKey("dbo.SalaryPayDetails");
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SalaryPayDetails", new[] { "Pay_Id", "Employee_Id" });
            DropColumn("dbo.SalaryPayDetails", "Workgroup_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalaryPayDetails", "Workgroup_Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.SalaryPayDetails");
            AlterColumn("dbo.SalaryPayDetails", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SalaryPayDetails", "Id");
            CreateIndex("dbo.SalaryPayDetails", "Workgroup_Id");
            AddForeignKey("dbo.SalaryPayDetails", "Workgroup_Id", "dbo.Workgroups", "Id", cascadeDelete: true);
        }
    }
}
