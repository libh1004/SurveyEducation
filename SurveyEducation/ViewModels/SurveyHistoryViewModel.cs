using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public class SurveyHistoryViewModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SurveyId { get; set; }
        public string Answers { get; set; }
        public int Status { get; set; }
    }
}