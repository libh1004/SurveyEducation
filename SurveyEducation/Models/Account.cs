using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
       [Required(ErrorMessage = "Please enter username.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter thumbnail.")]
        public string Thumbnail { get; set; }
        [Required(ErrorMessage = "Please enter phonenumber.")]
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public string RoleNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime AddmissionDate { get; set; }
        public DateTime DateOfJoining { get; set; }
        public virtual SurveyHistory SurveyHistory { get; set; }
    }
}