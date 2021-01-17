namespace SchoolAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeTables", "Time", c => c.String());
            AddColumn("dbo.TimeTables", "Day", c => c.String());
            DropColumn("dbo.Courses", "Time");
            DropColumn("dbo.Courses", "Day");
            DropColumn("dbo.TimeTables", "TimeRange");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeTables", "TimeRange", c => c.String());
            AddColumn("dbo.Courses", "Day", c => c.String());
            AddColumn("dbo.Courses", "Time", c => c.String());
            DropColumn("dbo.TimeTables", "Day");
            DropColumn("dbo.TimeTables", "Time");
        }
    }
}
