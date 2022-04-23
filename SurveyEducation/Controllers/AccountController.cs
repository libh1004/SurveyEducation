using SurveyEducation.Data;
using SurveyEducation.Models;
using SurveyEducation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyEducation.Controllers
{
    public class AccountController : Controller
    {
        MyDbContext db = new MyDbContext();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel)
        {
            var user = new UserModel()
            {
                Fullname = userViewModel.Fullname,
                Phone = userViewModel.Phone,
                Email = userViewModel.Email,
                Address = userViewModel.Address,
                Password = userViewModel.Password,
                EmployeeNumber = userViewModel.EmployeeNumber,
                AddmissionDate = userViewModel.AddmissionDate,
                DateOfJoining = userViewModel.DateOfJoining
            };
            db.Users.Add(user);
            db.SaveChanges();
            return View("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            return View();
        }
    }
}