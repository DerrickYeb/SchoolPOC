namespace SchoolAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedConstraint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.TimeTables", "CourseId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseID" });
            DropIndex("dbo.TimeTables", new[] { "CourseId" });
            RenameColumn(table: "dbo.Courses", name: "Id", newName: "CourseId");
            DropPrimaryKey("dbo.Courses");
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.TimeTables");
            AlterColumn("dbo.Courses", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Students", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.TimeTables", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TimeTables", "CourseId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Courses", "CourseId");
            AddPrimaryKey("dbo.Students", "StudentId");
            AddPrimaryKey("dbo.TimeTables", "Id");
            CreateIndex("dbo.Students", "CourseId");
            CreateIndex("dbo.TimeTables", "CourseId");
            AddForeignKey("dbo.Students", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.TimeTables", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeTables", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropIndex("dbo.TimeTables", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropPrimaryKey("dbo.TimeTables");
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.TimeTables", "CourseId", c => c.Guid(nullable: false));
            AlterColumn("dbo.TimeTables", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Students", "CourseId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Students", "StudentId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Courses", "CourseId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.TimeTables", "Id");
            AddPrimaryKey("dbo.Students", "StudentId");
            AddPrimaryKey("dbo.Courses", "Id");
            RenameColumn(table: "dbo.Courses", name: "CourseId", newName: "Id");
            CreateIndex("dbo.TimeTables", "CourseId");
            CreateIndex("dbo.Students", "CourseID");
            AddForeignKey("dbo.TimeTables", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "CourseID", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
