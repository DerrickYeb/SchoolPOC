namespace SchoolAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseModelDayAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Day", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Day");
        }
    }
}
