using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public class SurveyViewModel
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
            [Required(ErrorMessage = "Please enter start time.")]
            [DataType(DataType.DateTime)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime StartTime { get; set; }
            [Required(ErrorMessage = "Please enter end time.")]
            [DataType(DataType.DateTime)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime EndTime { get; set; }
            [Required(ErrorMessage = "Please enter creator.")]
            public DateTime CreatedBy { get; set; }
            [Required(ErrorMessage = "Please enter description.")]
            public string Description { get; set; }
            public string Tag { get; set; }
            public StatusValue Status { get; set; }
            public virtual SurveyHistory SurveyHistory { get; set; }
            public int QuestionId { get; set; }
            [ForeignKey("QuestionId")]
            public virtual ICollection<Question> Questions { get; set; }
        }
    }
}