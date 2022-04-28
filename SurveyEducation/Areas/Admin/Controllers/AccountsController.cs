using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SurveyEducation.Data;
using SurveyEducation.Models;
using SurveyEducation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace SurveyEducation.Areas.Admin.Controllers
{
    public class AccountsController : Controller
    {
        MyDbContext db = new MyDbContext();
        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.ListAccount = this.db.Account.ToList();

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

            var account = from p in db.Account
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                account = account.Where(p => p.UserName.Contains(searchString) || p.Email.Contains(searchString) || p.Thumnail.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "id_desc":
                    account = account.OrderByDescending(p => p.Id);
                    break;
                default:
                    account = account.OrderBy(p => p.Id);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(account.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModel accountVM)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account()
                {
                    UserName = accountVM.UserName,
                    Email = accountVM.Email,
                    Thumbnail = accountVM.Thumbnail,
                };
                db.Users.Add(account);
                db.SaveChanges();
                return View(account);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(account);
            }
        }
        [HttpGet]
        public ActionResult Edit(int accountId)
        {
            if (accountId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account acc = db.Account.Find(accountId);
            if (acc == null)
            {
                return HttpNotFound();
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var account = db.Account.Find(id);
            db.Account.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public List<Account> Search(string keyword)
        {
            if (keyword != null)
            {
                var result = from p in db.Account.Where(a => a.Phone.Equals(keyword)) select p;
                return result.ToList();
            }
            return null;
        }
        [HttpPost]
        public ActionResult Delete(IEnumerable<int> idDelete)
        {
            foreach (var item in idDelete)
            {
                return View(db.Account.ToList());
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

    }
}