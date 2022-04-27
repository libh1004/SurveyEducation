using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum Role
    {
        Admin,
        FacultyStaff,
        Student
    }
    public class Account : IdentityUser
    {
        public string UserName { get; set; }
        public DateTime DisabledAt { get; set; }
        public string Address { get; set; }
        public string Thumbnail { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public string RoleNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime AddmissionDate { get; set; }
        public DateTime DateOfJoining { get; set; }
        public virtual SurveyHistory SurveyHistory { get; set; }
    }
}