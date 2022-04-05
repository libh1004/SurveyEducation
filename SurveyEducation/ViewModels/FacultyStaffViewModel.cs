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
        public int EmployeeNumber { get; set; }
        [Required(ErrorMessage = "Please enter full name.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter class.")]
        public string Class { get; set; }
        [Required(ErrorMessage = "Please enter specification.")]
        public string Specification { get; set; }
        [Required(ErrorMessage = "Please enter section.")]
        public string Section { get; set; }
        [Required(ErrorMessage = "Please enter date of joining.")]
        public DateTime DateJoining { get; set; }
    }
}