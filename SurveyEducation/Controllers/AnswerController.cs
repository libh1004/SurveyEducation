using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using SurveyEducation.Data;
using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SurveyEducation.Areas.User.Controllers
{
    public class AnswerController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAnswer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveAnswer()
        {
            return View();
        }

        [HttpGet]
        public dynamic GetSurvey(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            else
            {
                var returnJson = JsonConvert.SerializeObject(survey, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return returnJson;
            }
        }
        [HttpPost]
        public dynamic SubmitSurvey()
        {
            var req = Request.InputStream;
            var json = new StreamReader(req).ReadToEnd();
            dynamic jsonObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
            var surveyId = jsonObject["SurveyId"];
            var answers = jsonObject["Answers"];
            var surveyHistory = new SurveyHistory();
            surveyHistory.Answers = JsonConvert.SerializeObject(answers);
            surveyHistory.SurveyId = Convert.ToInt32(surveyId);
            surveyHistory.UserId = Convert.ToInt32(User.Identity.GetUserId());
            surveyHistory.Status = 1;
            db.SurveyHistories.Add(surveyHistory);
            db.SaveChanges();
            var returnJson = JsonConvert.SerializeObject(surveyHistory, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return returnJson;
        }
    }
}