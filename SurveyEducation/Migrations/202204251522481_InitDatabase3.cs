namespace SurveyEducation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Content", c => c.String());
            AddColumn("dbo.AspNetUsers", "Thumbnail", c => c.String());
            DropColumn("dbo.AspNetUsers", "Fullname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String());
            DropColumn("dbo.AspNetUsers", "Thumbnail");
            DropColumn("dbo.Questions", "Content");
        }
    }
}
