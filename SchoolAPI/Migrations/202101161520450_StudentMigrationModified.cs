namespace SchoolAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentMigrationModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Guidean", c => c.String());
            AddColumn("dbo.Students", "GuideanContact", c => c.String());
            AddColumn("dbo.Students", "Class", c => c.String());
            AddColumn("dbo.Students", "AcademicYear", c => c.String());
            DropColumn("dbo.Students", "OtherName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "OtherName", c => c.String());
            DropColumn("dbo.Students", "AcademicYear");
            DropColumn("dbo.Students", "Class");
            DropColumn("dbo.Students", "GuideanContact");
            DropColumn("dbo.Students", "Guidean");
        }
    }
}
