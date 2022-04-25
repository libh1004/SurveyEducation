using SurveyEducation.Data;
using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyEducation.Areas.Admin.Controllers
{
    public class SurveyController : Controller
    {
        MyDbContext db = new MyDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Surveys.ToList());
        }

        [HttpGet]
        public ActionResult AddSurvey()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveSurvey(Survey survey)
        {
            var newSurvey = db.Surveys.Add(survey);
            db.SaveChanges();
            return Json(newSurvey);
        }
        [HttpGet]
        public ActionResult Create2()
        {
            return View();
        }
    }
}