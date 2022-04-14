using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public enum TypeQuestion
    {
        Text,
        SelectOne,
        SelectMany
    }
    public class AnswerViewModel
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [Required(ErrorMessage = "Please select type question.")]
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public TypeQuestion QuestionType { get; set; }
        [Required(ErrorMessage = "Please enter position.")]
        public string Position { get; set; }
        public int UserQuestionId { get; set; }
        [ForeignKey("UserQuestionId")]
        public virtual UserQuestion UserQuestion { get; set; }
        public string Content { get; set; }
    }
}