using System.Data.Entity.Migrations;

namespace SalaryApp.DataLayer.Migrations
{
    public partial class AddWorkdaysInLogsheet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logsheets", "Day_1", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_2", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_3", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_4", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_5", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_6", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_7", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_8", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_9", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_10", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_11", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_12", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_13", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_14", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_15", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_16", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_17", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_18", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_19", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_20", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_21", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_22", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_23", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_24", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_25", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_26", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_27", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_28", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_29", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_30", c => c.Int(false));
            AddColumn("dbo.Logsheets", "Day_31", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Logsheets", "Day_31");
            DropColumn("dbo.Logsheets", "Day_30");
            DropColumn("dbo.Logsheets", "Day_29");
            DropColumn("dbo.Logsheets", "Day_28");
            DropColumn("dbo.Logsheets", "Day_27");
            DropColumn("dbo.Logsheets", "Day_26");
            DropColumn("dbo.Logsheets", "Day_25");
            DropColumn("dbo.Logsheets", "Day_24");
            DropColumn("dbo.Logsheets", "Day_23");
            DropColumn("dbo.Logsheets", "Day_22");
            DropColumn("dbo.Logsheets", "Day_21");
            DropColumn("dbo.Logsheets", "Day_20");
            DropColumn("dbo.Logsheets", "Day_19");
            DropColumn("dbo.Logsheets", "Day_18");
            DropColumn("dbo.Logsheets", "Day_17");
            DropColumn("dbo.Logsheets", "Day_16");
            DropColumn("dbo.Logsheets", "Day_15");
            DropColumn("dbo.Logsheets", "Day_14");
            DropColumn("dbo.Logsheets", "Day_13");
            DropColumn("dbo.Logsheets", "Day_12");
            DropColumn("dbo.Logsheets", "Day_11");
            DropColumn("dbo.Logsheets", "Day_10");
            DropColumn("dbo.Logsheets", "Day_9");
            DropColumn("dbo.Logsheets", "Day_8");
            DropColumn("dbo.Logsheets", "Day_7");
            DropColumn("dbo.Logsheets", "Day_6");
            DropColumn("dbo.Logsheets", "Day_5");
            DropColumn("dbo.Logsheets", "Day_4");
            DropColumn("dbo.Logsheets", "Day_3");
            DropColumn("dbo.Logsheets", "Day_2");
            DropColumn("dbo.Logsheets", "Day_1");
        }
    }
}