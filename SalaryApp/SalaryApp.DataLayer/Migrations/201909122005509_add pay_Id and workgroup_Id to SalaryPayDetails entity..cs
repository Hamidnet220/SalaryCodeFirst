namespace SalaryApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpay_Idandworkgroup_IdtoSalaryPayDetailsentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalaryPayDetails", "Pay_Id", "dbo.Pays");
            DropForeignKey("dbo.SalaryPayDetails", "WorkGroup_Id", "dbo.Workgroups");
            DropIndex("dbo.SalaryPayDetails", new[] { "Pay_Id" });
            DropIndex("dbo.SalaryPayDetails", new[] { "WorkGroup_Id" });
            AlterColumn("dbo.SalaryPayDetails", "Pay_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SalaryPayDetails", "Workgroup_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SalaryPayDetails", "Pay_Id");
            CreateIndex("dbo.SalaryPayDetails", "Workgroup_Id");
            AddForeignKey("dbo.SalaryPayDetails", "Pay_Id", "dbo.Pays", "Id", cascadeDelete: false);
            AddForeignKey("dbo.SalaryPayDetails", "Workgroup_Id", "dbo.Workgroups", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryPayDetails", "Workgroup_Id", "dbo.Workgroups");
            DropForeignKey("dbo.SalaryPayDetails", "Pay_Id", "dbo.Pays");
            DropIndex("dbo.SalaryPayDetails", new[] { "Workgroup_Id" });
            DropIndex("dbo.SalaryPayDetails", new[] { "Pay_Id" });
            AlterColumn("dbo.SalaryPayDetails", "Workgroup_Id", c => c.Int());
            AlterColumn("dbo.SalaryPayDetails", "Pay_Id", c => c.Int());
            CreateIndex("dbo.SalaryPayDetails", "WorkGroup_Id");
            CreateIndex("dbo.SalaryPayDetails", "Pay_Id");
            AddForeignKey("dbo.SalaryPayDetails", "WorkGroup_Id", "dbo.Workgroups", "Id");
            AddForeignKey("dbo.SalaryPayDetails", "Pay_Id", "dbo.Pays", "Id");
        }
    }
}
