using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter message.")]
        public string Message { get; set; }
    }
}