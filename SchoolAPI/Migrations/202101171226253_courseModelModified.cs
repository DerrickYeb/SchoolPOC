namespace SchoolAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseModelModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseCode", c => c.String());
            DropColumn("dbo.Courses", "Time");
            DropColumn("dbo.Courses", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Day", c => c.String());
            AddColumn("dbo.Courses", "Time", c => c.String());
            DropColumn("dbo.Courses", "CourseCode");
        }
    }
}
