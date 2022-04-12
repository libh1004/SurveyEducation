﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public enum TypeQuestion
    {
        Text,
        SelectOne,
        SelectMany
    }
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public TypeQuestion QuestionType { get; set; }
        public string Position { get; set; }
        public string Content { get; set; }
    }
}