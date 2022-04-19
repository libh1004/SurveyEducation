using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class SurveyHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<User> Users { get; set; }
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public virtual ICollection<Survey> Surveys { get; set; }
        public string Answers { get; set; }
        public int Status { get; set; }
    }
}