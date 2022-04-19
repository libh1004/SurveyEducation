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
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SurveyHistory> SurveyHistories { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}