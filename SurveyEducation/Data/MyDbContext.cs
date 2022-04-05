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
        public DbSet<Student> Students { get; set; }
        public DbSet<FacultyOrStaff> FacultyOrStaffs { get; set; }
    }
}