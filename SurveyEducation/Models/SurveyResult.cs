using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{

    public class SurveyResult
    {
        public Survey Survey { get; set; }
        public SurveyHistory SurveyHistory { get; set; }
        public List<Result> Answers { get; set; }
    }
}