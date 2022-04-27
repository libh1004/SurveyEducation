namespace SurveyEducation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Surveys", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Surveys", "Name");
        }
    }
}
