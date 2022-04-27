using SurveyEducation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}