using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
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
    public class Question
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public string Position { get; set; }
        public Status Status { get; set; }
    }
}