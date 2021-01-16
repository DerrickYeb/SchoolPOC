namespace SchoolAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Guid(nullable: false),
                        Title = c.String(),
                        Time = c.String(),
                        Student_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OtherName = c.String(),
                        Address = c.String(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TimeTables", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Student_Id", "dbo.Students");
            DropIndex("dbo.TimeTables", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "User_Id" });
            DropIndex("dbo.Courses", new[] { "Student_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.TimeTables");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
