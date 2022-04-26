using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyEducation.Models
{
    public class AppRole : IdentityRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}