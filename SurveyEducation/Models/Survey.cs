using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum StatusValue
    {
        Draft,
        Finished
    }
    public class Survey
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public StatusValue Status { get; set; }
        public virtual SurveyHistory SurveyHistory { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual ICollection<Question> Questions { get; set; }
    }
}