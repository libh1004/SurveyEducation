using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public enum Type
    {
        Text,
        SelectOne,
        SelectMany
    }
    public enum Status
    {
        Active,
        Deactive
    }
    public class QuestionViewModel
    {
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }
        [Required(ErrorMessage = "Please enter title survey.")]
        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter select type.")]
        public Type Type { get; set; }
        [Required(ErrorMessage = "Please enter position.")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Please select status survey.")]
        public Status Status { get; set; }
    }
}