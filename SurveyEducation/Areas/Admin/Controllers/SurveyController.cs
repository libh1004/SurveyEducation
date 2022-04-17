using SurveyEducation.Data;
using SurveyEducation.Models;
using SurveyEducation.ViewModels;
using System;
using System.Collections.Generic;
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyViewModel surveyvm)
        {
            var survey = new Survey()
            {
                Name = surveyvm.Name,
                StartedAt = surveyvm.StartedAt,
                CreatedAt = surveyvm.CreatedAt,
                UpdatedAt = surveyvm.UpdatedAt,
                DeletedAt = surveyvm.DeletedAt,
                CreatedBy = surveyvm.CreatedBy,
                UpdatedBy = surveyvm.UpdatedBy,
                DeletedBy = surveyvm.DeletedBy,
                Status = (Models.StatusValue)surveyvm.Status,
                Image = surveyvm.Image,
                Detail = surveyvm.Detail,
                Tag = surveyvm.Tag
            };
            db.Surveys.Add(survey);
            db.SaveChanges();
            return View("Index");
        }
        [HttpGet]
        public ActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2(SurveyViewModel surveyvm)
        {
            var survey = new Survey()
            {
                Name = surveyvm.Name,
                StartedAt = surveyvm.StartedAt,
                CreatedAt = surveyvm.CreatedAt,
                UpdatedAt = surveyvm.UpdatedAt,
                DeletedAt = surveyvm.DeletedAt,
                CreatedBy = surveyvm.CreatedBy,
                UpdatedBy = surveyvm.UpdatedBy,
                DeletedBy = surveyvm.DeletedBy,
                Status = (Models.StatusValue)surveyvm.Status,
                Image = surveyvm.Image,
                Detail = surveyvm.Detail,
                Tag = surveyvm.Tag
            };
            db.Surveys.Add(survey);
            db.SaveChanges();
            return View("Index");
        }
    }
}