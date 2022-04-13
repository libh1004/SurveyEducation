using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class Student
    {
        public string RollNo { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Class { get; set; }
        public string Specification { get; set; }
        public string Section { get; set; }
        public DateTime AdmissionDate { get; set; }
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}