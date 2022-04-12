using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum TypeValue
    {
        Text,
        SelectOne,
        SelectMany
    }
    public class UserQuestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public TypeValue AnswerType { get; set; }
    }
}