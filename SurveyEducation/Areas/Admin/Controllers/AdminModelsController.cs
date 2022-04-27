using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SurveyEducation.Data;
using SurveyEducation.Models;

namespace SurveyEducation.Areas.Admin.Controllers
{
    public class AdminModelsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Admin/AdminModels
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

            var adminModels = from p in db.Admins
                             select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                adminModels = adminModels.Where(p => p.Username.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "id_desc":
                    adminModels = adminModels.OrderByDescending(p => p.Id);
                    break;
                default:
                    adminModels = adminModels.OrderBy(p => p.Id);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(adminModels.ToPagedList(
                pageNumber, pageSize));
        }

        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: Admin/AdminModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = db.Admins.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // GET: Admin/AdminModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Email,Password,Phone,Thumbnail")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(adminModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminModel);
        }

        // GET: Admin/AdminModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = db.Admins.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // POST: Admin/AdminModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Email,Password,Phone,Thumbnail")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminModel);
        }

        // GET: Admin/AdminModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = db.Admins.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // POST: Admin/AdminModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminModel adminModel = db.Admins.Find(id);
            db.Admins.Remove(adminModel);
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
