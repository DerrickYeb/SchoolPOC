namespace SchoolAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Student_Id", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "Student_Id" });
            RenameColumn(table: "dbo.Courses", name: "CourseId", newName: "Id");
            AddColumn("dbo.Courses", "Time", c => c.String());
            AddColumn("dbo.Courses", "Day", c => c.String());
            AddColumn("dbo.Students", "Guidian", c => c.String());
            AddColumn("dbo.Students", "Gender", c => c.String());
            AddColumn("dbo.Students", "CourseID", c => c.Guid(nullable: false));
            AddColumn("dbo.TimeTables", "TimeRange", c => c.String());
            AlterColumn("dbo.Courses", "Title", c => c.String(maxLength: 50));
            CreateIndex("dbo.Students", "CourseID");
            AddForeignKey("dbo.Students", "CourseID", "dbo.Courses", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "CourseCode");
            DropColumn("dbo.Courses", "Student_Id");
            DropColumn("dbo.Students", "Guidean");
            DropColumn("dbo.TimeTables", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeTables", "Time", c => c.String());
            AddColumn("dbo.Students", "Guidean", c => c.String());
            AddColumn("dbo.Courses", "Student_Id", c => c.Guid());
            AddColumn("dbo.Courses", "CourseCode", c => c.String());
            DropForeignKey("dbo.Students", "CourseID", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseID" });
            AlterColumn("dbo.Courses", "Title", c => c.String());
            DropColumn("dbo.TimeTables", "TimeRange");
            DropColumn("dbo.Students", "CourseID");
            DropColumn("dbo.Students", "Gender");
            DropColumn("dbo.Students", "Guidian");
            DropColumn("dbo.Courses", "Day");
            DropColumn("dbo.Courses", "Time");
            RenameColumn(table: "dbo.Courses", name: "Id", newName: "CourseId");
            CreateIndex("dbo.Courses", "Student_Id");
            AddForeignKey("dbo.Courses", "Student_Id", "dbo.Students", "StudentId");
        }
    }
}
