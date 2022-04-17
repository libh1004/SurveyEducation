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
    public class FacultyStaffsController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Feedback
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

            var facultyStaffs = from p in db.FacultyStaffs
                                select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                facultyStaffs = facultyStaffs.Where(p => p.EmployeeNumber.Contains(searchString) || p.Password.Equals(searchString) || p.Class.Equals(searchString) || p.Specification.Equals(searchString) || p.Section.Equals(searchString) || p.DateOfJoining.Equals(searchString));
            }
            switch (sortOrder)
            {

                case "id_desc":
                    facultyStaffs = facultyStaffs.OrderByDescending(p => p.Name);
                    break;
                default:
                    facultyStaffs = facultyStaffs.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(facultyStaffs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/FacultyStaffs
        public ActionResult Index()
        {
            return View(db.FacultyStaffs.ToList());
        }

        // GET: Admin/FacultyStaffs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyStaff facultyStaff = db.FacultyStaffs.Find(id);
            if (facultyStaff == null)
            {
                return HttpNotFound();
            }
            return View(facultyStaff);
        }

        // GET: Admin/FacultyStaffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FacultyStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeNumber,Name,Password,Class,Specification,Section,DateOfJoining")] FacultyStaff facultyStaff)
        {
            if (ModelState.IsValid)
            {
                db.FacultyStaffs.Add(facultyStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facultyStaff);
        }

        // GET: Admin/FacultyStaffs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyStaff facultyStaff = db.FacultyStaffs.Find(id);
            if (facultyStaff == null)
            {
                return HttpNotFound();
            }
            return View(facultyStaff);
        }

        // POST: Admin/FacultyStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeNumber,Name,Password,Class,Specification,Section,DateOfJoining")] FacultyStaff facultyStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultyStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facultyStaff);
        }

        // GET: Admin/FacultyStaffs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyStaff facultyStaff = db.FacultyStaffs.Find(id);
            if (facultyStaff == null)
            {
                return HttpNotFound();
            }
            return View(facultyStaff);
        }

        // POST: Admin/FacultyStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FacultyStaff facultyStaff = db.FacultyStaffs.Find(id);
            db.FacultyStaffs.Remove(facultyStaff);
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
