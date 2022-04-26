using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public class QuestionViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter content.")]
        public string Content { get; set; }
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }
        public string Answers { get; set; }
        public int Status { get; set; }
    }
}