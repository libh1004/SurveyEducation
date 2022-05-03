using PagedList;
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

        [HttpGet]
        public ViewResult Survey(string sortOrder, string currentFilter, string searchString, int? page)
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