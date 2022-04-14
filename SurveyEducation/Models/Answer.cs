using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum TypeQuestion
    {
        Text,
        SelectOne,
        SelectMany
    }
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public int UserQuestionId { get; set; }
        [ForeignKey("UserQuestionId")]
        public virtual  UserQuestion UserQuestion { get; set; }
        public TypeQuestion QuestionType { get; set; }
        public string Position { get; set; }
        public string Content { get; set; }
    }
}