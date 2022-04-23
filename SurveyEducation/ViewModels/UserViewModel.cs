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
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter full name.")]
        public string Fullname { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DisabledAt { get; set; }
        [Required(ErrorMessage = "Please enter phone.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter address.")]
        [DataType(DataType.EmailAddress)]
        public string Address { get; set; }
        public int Status { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public RoleValue RoleId { get; set; }
        [Required(ErrorMessage = "Please enter employee number.")]
        public string EmployeeNumber { get; set; }
        [Required(ErrorMessage = "Please enter admission date.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AddmissionDate { get; set; }
        [Required(ErrorMessage = "Please enter date of joining.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfJoining { get; set; }
        public virtual SurveyHistory SurveyHistory { get; set; }
    }
}