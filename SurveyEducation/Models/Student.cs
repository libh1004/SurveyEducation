using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class Student
    {
        public int RollNo { get; set; }
        public string FullName { get; set; }
        public string Class { get; set; }
        public string Specification { get; set; }
        public string Section { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}