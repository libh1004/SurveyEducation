using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public enum TypeValue
    {
        Text,
        SelectOne,
        SelectMany
    }
    public class UserQuestionViewModel
    {
        [Key]
        public int Id { get; set; }
        public string RollNo { get; set; }
        [ForeignKey("RollNo")]
        public virtual Student Student { get; set; }
        public int? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public virtual ICollection<Answer> Answers { get; set; }
        public TypeValue AnswerType { get; set; }
    }
}