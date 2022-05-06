using Microsoft.AspNet.Identity.EntityFramework;
using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SurveyEducation.Data
{
    public class MyDbContext : IdentityDbContext<Account>
    {
        public MyDbContext() : base("name=ConnectionString")
        {
        }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyHistory> SurveyHistories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}