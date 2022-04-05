using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        public int RollNo { get; set; }
        [Required(ErrorMessage = "Please enter full name.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter class.")]
        public string Class { get; set; }
        [Required(ErrorMessage = "Please enter specification.")]
        public string Specification { get; set; }
        [Required(ErrorMessage = "Please enter section.")]
        public string Section { get; set; }
        [Required(ErrorMessage = "Please enter admission date.")]
        public DateTime AdmissionDate { get; set; }
    }
}