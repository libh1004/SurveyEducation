using Newtonsoft.Json;
using SurveyEducation.Data;
using SurveyEducation.Models;
using SurveyEducation.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public JsonResult SaveSurvey()
        {
            var req = Request.InputStream;
            var json = new StreamReader(req).ReadToEnd();
            dynamic jsonObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
            var name = jsonObject["name"];
            var startTime = jsonObject["startTime"];
            var endTime = jsonObject["endTime"];
            var description = jsonObject["description"];
            var questions = jsonObject["questions"];
            var survey = new Survey();
            survey.Name = name;
            survey.StartTime = Convert.ToDateTime(startTime);
            survey.EndTime = Convert.ToDateTime(endTime);
            survey.Description = description;
            survey.Status = StatusValue.Draft;
            var newSurvey = db.Surveys.Add(survey);
            db.SaveChanges();
            foreach (var q in questions)
            {
                var questionValue = q["nameLarge"];
                var questionType = Convert.ToInt32(q["type"]);
                dynamic lstStr = null;
                if (questionType != 1)
                {
                    lstStr = string.Join("|", q["answers"]);
                }
                var questionAnswers = lstStr;

                var question = new Question();
                question.SurveyId = newSurvey.Id;
                question.QuestionType = (SurveyEducation.Models.Type)questionType;
                question.Content = questionValue;
                question.Answers = questionAnswers;
                question.Status = 1;
                db.Questions.Add(question);
                db.SaveChanges();
            }
            return Json(newSurvey);
        }
    }
}