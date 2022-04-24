using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public enum RoleValue
    {
        Admin,
        FacultyStaff,
        Student
    }
    public class AccountViewModel
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}