using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum TypeValue
    {
        Text,
        SelectOne,
        SelectMany
    }
    public class UserQuestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Student Student { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public virtual ICollection<Answer> Answers { get; set; }
        public TypeValue AnswerType { get; set; }
    }
}