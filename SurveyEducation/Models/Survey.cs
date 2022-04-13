using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum StatusValue
    {
        Draft,
        Active, 
        Deactive,
        Delected,
        Finished
    }
    public class Survey
    {
        public int Id { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public string Name { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedBy { get; set; }
        public DateTime DeletedBy { get; set; }
        public StatusValue Status { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public string Tag { get; set; }

    }
}