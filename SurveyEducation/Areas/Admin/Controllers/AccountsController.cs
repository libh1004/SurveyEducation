using Microsoft.AspNet.Identity;
using SurveyEducation.Data;
using SurveyEducation.Models;
using SurveyEducation.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private UserManager<Account> userManager;
        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }   

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Users.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AccountViewModel accountVM)
        {
            Account user = new Account();
            user.UserName = accountVM.UserName;
            user.Status = 1;
            user.Email = accountVM.Email;
            user.RoleNumber = accountVM.RoleNumber;
            user.PasswordHash = accountVM.Password;
            user.AddmissionDate = DateTime.Now;
            user.EmployeeNumber = accountVM.EmployeeNumber;
            user.DateOfJoining = DateTime.Now;       

            var result = await userManager.CreateAsync(user, user.PasswordHash);
            db.SaveChanges();
            if (result.Succeeded)
            {
                return View("Login");
            }
            else
            {
                return View("Register");
            }
        }
        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Users.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,DisabledAt,Address,Thumbnail,PhoneNumber,Status,RoleNumber,EmployeeNumber,AddmissionDate,DateOfJoining")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Users.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Users.Find(id);
            db.Users.Remove(account);
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



