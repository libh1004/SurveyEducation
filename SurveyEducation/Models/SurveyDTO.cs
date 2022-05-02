using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class SurveyDTO
    {
        public Survey Survey { get; set; }
        public List<SurveyHistory> SurveyHistories { get; set; }
    }
}