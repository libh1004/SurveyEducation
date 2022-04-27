namespace SurveyEducation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "UserId");
        }
    }
}
