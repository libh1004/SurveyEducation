using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public class FacultyStaffViewModel
    {
        [Key]
        public string EmployeeNumber { get; set; }
        [Required(ErrorMessage = "Please enter full name.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Please enter class.")]
        public string Class { get; set; }
        public string Specification { get; set; }
        public string Section { get; set; }
        [Required(ErrorMessage = "Please enter date of joining.")]
        public DateTime DateOfJoining { get; set; }
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }



}