using SurveyEducation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SurveyEducation.Controllers
{
    public class HomeController : Controller
    {
        // GET: User/Home
        MyDbContext db = new MyDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
            
        public ActionResult Survey()
        {
            //return View(db.Surveys.ToList());
            return View();
        }
        public ActionResult About()
        {
            //return View(db.Surveys.ToList());
            return View();
        }
        public ActionResult Contact()
        {
            //return View(db.Surveys.ToList());
            return View();
        }
        public ActionResult Details(int? id)
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
    }
}