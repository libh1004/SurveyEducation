using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SurveyEducation.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=ConnectionString")
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<FacultyStaff> FacultyStaffs { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
    }
}