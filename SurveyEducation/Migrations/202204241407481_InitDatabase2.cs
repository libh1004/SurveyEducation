namespace SurveyEducation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Surveys", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Surveys", "CreatedBy", c => c.DateTime(nullable: false));
        }
    }
}
