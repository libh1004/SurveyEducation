using Newtonsoft.Json;
using SurveyEducation.Data;
using SurveyEducation.Models;
using SurveyEducation.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult StatisticSurveys()
        {
            return View();
        }

        [HttpPost]
        public string SaveSurvey()
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
            var returnJson = JsonConvert.SerializeObject(newSurvey, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return returnJson;
        }

        [HttpGet]
        public ActionResult Details(int? id)
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
            return View(survey);
        }

        public ActionResult Delete(int? id)
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
                db.Surveys.Remove(survey);
                return RedirectToAction("Index");
            }
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
        public ActionResult StatisticSurvey()
        {
            return View();
        }

        [HttpGet]
        public dynamic StatisticSurveyApi()
        {
            var lst = new List<SurveyDTO>();
            var surveys = db.Surveys.ToList();
            foreach(var s in surveys)
            {
                var surveyHistory = db.SurveyHistories.Where(x => x.SurveyId == s.Id).ToList();
                var surveyDTO = new SurveyDTO();
                surveyDTO.Survey = s;
                surveyDTO.SurveyHistories = surveyHistory;
                lst.Add(surveyDTO);
            }

            var returnJson = JsonConvert.SerializeObject(lst, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return returnJson;
        }
    }
}