using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Thumbnail { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}