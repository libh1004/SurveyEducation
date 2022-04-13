using SurveyEducation.Models;
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
        public string RollNo { get; set; }
        [Required(ErrorMessage = "Please enter full name.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter class.")]
        public string Class { get; set; }
        public string Specification { get; set; }
        public string Section { get; set; }
        [Required(ErrorMessage = "Please enter admission date.")]
        public DateTime AdmissionDate { get; set; }
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}