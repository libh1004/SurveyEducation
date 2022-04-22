using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum RoleValue
    {
        Admin,
        FacultyStaff,
        Student
    }
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DisabledAt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }
        public RoleValue RoleId { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime AddmissionDate { get; set; }
        public DateTime DateOfJoining { get; set; }
        public virtual SurveyHistory SurveyHistory { get; set; }
    }
}