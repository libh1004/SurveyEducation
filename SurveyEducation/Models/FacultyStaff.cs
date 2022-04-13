using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class FacultyStaff
    {
        public string Name { get; set; }
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public string Class { get; set; }
        public string Specification { get; set; }
        public string Section { get; set; }
        public DateTime DateOfJoining { get; set; }
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}