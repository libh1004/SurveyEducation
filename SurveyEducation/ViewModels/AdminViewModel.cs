using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public class AdminViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter user name.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter phone.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter url of thumbnail.")]
        public string Thumbnail { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}