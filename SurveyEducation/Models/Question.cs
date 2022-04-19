﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }
        public string Answers { get; set; }
        public int Status { get; set; }
    }
}