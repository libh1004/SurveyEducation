using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyEducation.ViewModels
{
    public enum StatusValue
    {
        Draft,
        Active,
        Deactive,
        Delected,
        Finished
    }
    public class SurveyViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name survey.")]
        public virtual ICollection<Question> Questions { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter started time.")]
        public DateTime StartedAt { get; set; }
        [Required(ErrorMessage = "Please enter created time.")]
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "Please enter updated time.")]
        public DateTime UpdatedAt { get; set; }
        [Required(ErrorMessage = "Please enter deleted time.")]
        public DateTime DeletedAt { get; set; }
        [Required(ErrorMessage = "Please enter creator.")]
        public DateTime CreatedBy { get; set; }
        [Required(ErrorMessage = "Please enter editor.")]
        public DateTime UpdatedBy { get; set; }
        [Required(ErrorMessage = "Please enter deleter.")]
        public DateTime DeletedBy { get; set; }
        [Required(ErrorMessage = "Please select status.")]
        public StatusValue Status { get; set; }
        [Required(ErrorMessage = "Please enter image.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Please enter detail.")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "Please enter tag.")]
        public string Tag { get; set; }
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}