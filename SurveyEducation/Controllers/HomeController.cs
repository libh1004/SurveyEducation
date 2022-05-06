using SurveyEducation.Data;
using SurveyEducation.Models;
using System;
using System.Linq;
using System.Net;
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
            return View(db.Surveys.ToList());
        }

        public ActionResult About()
        {
            //return View(db.Surveys.ToList());
            return View();
        }
        public ActionResult Blog()
        {
            var Blog = db.Blogs.OrderByDescending(p => p.Id).FirstOrDefault();
            return View(db.Blogs.ToList());
        }
        public ActionResult BlogDetails(int? id)
        {
            var Blog = db.Blogs.OrderByDescending(p => p.Id).FirstOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        public ActionResult Contact()
        {
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Name,Email,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }
            return View("Contact");
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