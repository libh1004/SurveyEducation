namespace SurveyEducation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Surveys", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "UserQuestionId", "dbo.UserQuestions");
            DropForeignKey("dbo.UserQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.UserQuestions", "RollNo", "dbo.Students");
            DropForeignKey("dbo.UserQuestions", "FacultyStaff_EmployeeNumber", "dbo.FacultyStaffs");
            DropIndex("dbo.Surveys", new[] { "Admin_Id" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "UserQuestionId" });
            DropIndex("dbo.UserQuestions", new[] { "RollNo" });
            DropIndex("dbo.UserQuestions", new[] { "QuestionId" });
            DropIndex("dbo.UserQuestions", new[] { "FacultyStaff_EmployeeNumber" });
            CreateTable(
                "dbo.SurveyHistories",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        SurveyId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Answers = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.SurveyId });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DisabledAt = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        EmployeeNumber = c.String(),
                        AddmissionDate = c.DateTime(nullable: false),
                        DateOfJoining = c.DateTime(nullable: false),
                        SurveyHistory_UserId = c.Int(),
                        SurveyHistory_SurveyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyHistories", t => new { t.SurveyHistory_UserId, t.SurveyHistory_SurveyId })
                .Index(t => new { t.SurveyHistory_UserId, t.SurveyHistory_SurveyId });
            
            AddColumn("dbo.Surveys", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Surveys", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Surveys", "Description", c => c.String());
            AddColumn("dbo.Surveys", "QuestionId", c => c.Int(nullable: false));
            AddColumn("dbo.Surveys", "SurveyHistory_UserId", c => c.Int());
            AddColumn("dbo.Surveys", "SurveyHistory_SurveyId", c => c.Int());
            AddColumn("dbo.Questions", "Answers", c => c.String());
            CreateIndex("dbo.Surveys", new[] { "SurveyHistory_UserId", "SurveyHistory_SurveyId" });
            AddForeignKey("dbo.Surveys", new[] { "SurveyHistory_UserId", "SurveyHistory_SurveyId" }, "dbo.SurveyHistories", new[] { "UserId", "SurveyId" });
            DropColumn("dbo.Surveys", "Name");
            DropColumn("dbo.Surveys", "StartedAt");
            DropColumn("dbo.Surveys", "CreatedAt");
            DropColumn("dbo.Surveys", "UpdatedAt");
            DropColumn("dbo.Surveys", "DeletedAt");
            DropColumn("dbo.Surveys", "UpdatedBy");
            DropColumn("dbo.Surveys", "DeletedBy");
            DropColumn("dbo.Surveys", "Image");
            DropColumn("dbo.Surveys", "Detail");
            DropColumn("dbo.Surveys", "Admin_Id");
            DropColumn("dbo.Questions", "Title");
            DropColumn("dbo.Questions", "Type");
            DropColumn("dbo.Questions", "Position");
            DropTable("dbo.Admins");
            DropTable("dbo.Answers");
            DropTable("dbo.UserQuestions");
            DropTable("dbo.Students");
            DropTable("dbo.FacultyStaffs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FacultyStaffs",
                c => new
                    {
                        EmployeeNumber = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Password = c.String(),
                        Class = c.String(),
                        Specification = c.String(),
                        Section = c.String(),
                        DateOfJoining = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeNumber);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        RollNo = c.String(nullable: false, maxLength: 128),
                        Fullname = c.String(),
                        Password = c.String(),
                        Class = c.String(),
                        Specification = c.String(),
                        Section = c.String(),
                        AdmissionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RollNo);
            
            CreateTable(
                "dbo.UserQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollNo = c.String(maxLength: 128),
                        QuestionId = c.Int(),
                        AnswerId = c.Int(nullable: false),
                        AnswerType = c.Int(nullable: false),
                        FacultyStaff_EmployeeNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        UserQuestionId = c.Int(nullable: false),
                        QuestionType = c.Int(nullable: false),
                        Position = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        Thumbnail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "Position", c => c.String());
            AddColumn("dbo.Questions", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Title", c => c.String());
            AddColumn("dbo.Surveys", "Admin_Id", c => c.Int());
            AddColumn("dbo.Surveys", "Detail", c => c.String());
            AddColumn("dbo.Surveys", "Image", c => c.String());
            AddColumn("dbo.Surveys", "DeletedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Surveys", "UpdatedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Surveys", "DeletedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Surveys", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Surveys", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Surveys", "StartedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Surveys", "Name", c => c.String());
            DropForeignKey("dbo.Users", new[] { "SurveyHistory_UserId", "SurveyHistory_SurveyId" }, "dbo.SurveyHistories");
            DropForeignKey("dbo.Surveys", new[] { "SurveyHistory_UserId", "SurveyHistory_SurveyId" }, "dbo.SurveyHistories");
            DropIndex("dbo.Users", new[] { "SurveyHistory_UserId", "SurveyHistory_SurveyId" });
            DropIndex("dbo.Surveys", new[] { "SurveyHistory_UserId", "SurveyHistory_SurveyId" });
            DropColumn("dbo.Questions", "Answers");
            DropColumn("dbo.Surveys", "SurveyHistory_SurveyId");
            DropColumn("dbo.Surveys", "SurveyHistory_UserId");
            DropColumn("dbo.Surveys", "QuestionId");
            DropColumn("dbo.Surveys", "Description");
            DropColumn("dbo.Surveys", "EndTime");
            DropColumn("dbo.Surveys", "StartTime");
            DropTable("dbo.Users");
            DropTable("dbo.SurveyHistories");
            CreateIndex("dbo.UserQuestions", "FacultyStaff_EmployeeNumber");
            CreateIndex("dbo.UserQuestions", "QuestionId");
            CreateIndex("dbo.UserQuestions", "RollNo");
            CreateIndex("dbo.Answers", "UserQuestionId");
            CreateIndex("dbo.Answers", "QuestionId");
            CreateIndex("dbo.Surveys", "Admin_Id");
            AddForeignKey("dbo.UserQuestions", "FacultyStaff_EmployeeNumber", "dbo.FacultyStaffs", "EmployeeNumber");
            AddForeignKey("dbo.UserQuestions", "RollNo", "dbo.Students", "RollNo");
            AddForeignKey("dbo.UserQuestions", "QuestionId", "dbo.Questions", "Id");
            AddForeignKey("dbo.Answers", "UserQuestionId", "dbo.UserQuestions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Surveys", "Admin_Id", "dbo.Admins", "Id");
        }
    }
}
