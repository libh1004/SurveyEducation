using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using SurveyEducation.Data;
using SurveyEducation.Models;

namespace SurveyEducation.Areas.Admin.Controllers
{
    public class QuestionsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
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

            var questions = from p in db.Questions
                            select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                questions = questions.Where(p => p.SurveyId.Equals(searchString) || p.Survey.Equals(searchString) || p.Title.Equals(searchString) || p.Type.Equals(searchString) || p.Position.Equals(searchString) || p.Status.Equals(searchString));
            }
            switch (sortOrder)
            {

                case "id_desc":
                    questions = questions.OrderByDescending(p => p.Id);
                    break;
                default:
                    questions = questions.OrderBy(p => p.Id);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(questions.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Survey);
            return View(questions.ToList());
        }

        // GET: Admin/Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Admin/Questions/Create
        public ActionResult Create()
        {
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name");
            return View();
        }

        // POST: Admin/Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SurveyId,Title,Type,Position,Status")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", question.SurveyId);
            return View(question);
        }

        // GET: Admin/Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", question.SurveyId);
            return View(question);
        }

        // POST: Admin/Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SurveyId,Title,Type,Position,Status")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", question.SurveyId);
            return View(question);
        }

        // GET: Admin/Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Admin/Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
