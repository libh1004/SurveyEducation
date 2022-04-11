using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum TypeUser
    {
        Student,
        FacultyOrStaff
    }
    public class User
    {
        public int Id { get; set; }
        public TypeUser Type { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}