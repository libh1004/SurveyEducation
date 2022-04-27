using Newtonsoft.Json;
using SurveyEducation.Data;
using SurveyEducation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

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
    }
}