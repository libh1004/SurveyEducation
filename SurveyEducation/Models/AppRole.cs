using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum RoleValue
    {
        Admin,
        FacultyOrStaff, 
        Student
    }
    public class AppRole : IdentityRole
    {
        public int Id { get; set; }
        public RoleValue Name { get; set; }
        public string UserId { get; set; }
    }
}