using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SurveyEducation.Data;
using SurveyEducation.Models;
using SurveyEducation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace SurveyEducation.Areas.Admin.Controllers
{
    public class AccountsController : Controller
    {

        MyDbContext db = new MyDbContext();
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
    }
}