using Newtonsoft.Json;
using PagedList;
using SurveyEducation.Data;
using SurveyEducation.Models;
using SurveyEducation.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.ListSurvey = this.db.Surveys.ToList();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var surveys = from p in db.Surveys
                          select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                surveys = surveys.Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    surveys = surveys.OrderByDescending(p => p.Id);
                    break;
                default:
                    surveys = surveys.OrderBy(p => p.Id);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(surveys.ToPagedList(pageNumber, pageSize));
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
                question.QuestionType = questionType;
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

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Survey survey = db.Surveys.Find(id);
        //    if (survey == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        db.Surveys.Remove(survey);
        //        return RedirectToAction("Index");
        //    }
        //}
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
            foreach (var s in surveys)
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

        // mục đích thay đổi status của survey.
        // dùng cho trường hợp start và close survey
        [HttpPut]
        public dynamic ChangeStatusSurvey(int? id)
        {
            var req = Request.InputStream;
            var json = new StreamReader(req).ReadToEnd();
            dynamic jsonObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
            var status = jsonObject["name"];
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
                survey.Status = status;
                db.SaveChanges();
                var returnJson = JsonConvert.SerializeObject(survey, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return returnJson;
            }
        }

        [HttpGet]
        public ActionResult DetailStatisticSurvey(int? id)
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
            var lst = new List<Account>();
            var surveyHistory = db.SurveyHistories.Where(x => x.SurveyId == survey.Id).ToList();
            foreach (var item in surveyHistory)
            {
                var user = db.Users.Where(x => x.Id == item.UserId).FirstOrDefault();
                lst.Add(user);
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult ShowResultUser(int? id, string userId)
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
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            var surveyHistory = db.SurveyHistories.Where(s => s.UserId == user.Id && s.SurveyId == survey.Id).FirstOrDefault();
            if (surveyHistory == null)
            {
                return HttpNotFound();
            }
            if (user == null)
            {
                return HttpNotFound();
            }
            var listAnswer = JsonConvert.DeserializeObject<List<Result>>(surveyHistory.Answers);

            SurveyResult surveyResult = new SurveyResult()
            {
                Survey = survey,
                SurveyHistory = surveyHistory,
                Answers = listAnswer

            };
            return View(surveyResult);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartTime,EndTime,CreatedBy,Description,Tag,Status,SurveyHistory,QuestionId,Questions")] Models.Survey survey)
        {
            if (ModelState.IsValid)
            {
                ViewBag.message = "Edit Successfully";
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}