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
        [Key, Column(Order = 1)]
        public int UserId { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
        [Key, Column(Order = 2)]
        public int SurveyId { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public string Answers { get; set; }
        public int Status { get; set; }
    }
}