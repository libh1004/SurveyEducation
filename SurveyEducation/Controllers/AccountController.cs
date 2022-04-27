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

namespace SurveyEducation.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext db;
        private UserManager<Account> userManager;
        private RoleManager<AppRole> roleManager;
        private SignInManager<Account, string> signInManager;
        public AccountController()
        {
            db = new MyDbContext();
            UserStore<Account> userStore = new UserStore<Account>(db);
            userManager = new UserManager<Account>(userStore);
            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(db);
            roleManager = new RoleManager<AppRole>(roleStore);
        }
        public ActionResult Register()
        {
            return View();
        }
        public async Task<ActionResult> AddAccount(AccountViewModel accountVM)
        {
            Account user = new Account()
            {
                UserName = accountVM.UserName,
                Status = 1,
                PasswordHash = accountVM.Password,
                Email = accountVM.Email,
                RoleNumber = accountVM.RoleNumber,
                AddmissionDate = DateTime.Now,
                EmployeeNumber = accountVM.EmployeeNumber,
                DateOfJoining = DateTime.Now
            };
            
            var result = await userManager.CreateAsync(user, user.PasswordHash);
            db.Users.Add(user);
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
        public async Task<ActionResult> AddRole()
        {
            Account account = new Account();
            if(account.RoleNumber != null && account.AddmissionDate != null)
            {
                AppRole roleStudent = new AppRole()
                {
                    Name = "Student"
                };
                var result1 = await roleManager.CreateAsync(roleStudent);
                if (result1.Succeeded)
                {
                    return ViewBag.Message = "Add Role Successful!";
                }
                else
                {
                    return ViewBag.Message = "Add Role Fail!";
                }
            }
            else if(account.EmployeeNumber != null && account.DateOfJoining != null)
            {
                AppRole roleFacultyStaff = new AppRole()
                {
                    Name = "FacultyOrStaff"
                };
                var result2 = await roleManager.CreateAsync(roleFacultyStaff);
                if (result2.Succeeded)
                {
                    return ViewBag.Message = "Add Role Successful!";
                }
                else
                {
                    return ViewBag.Message = "Add Role Fail!";
                }
            }
            return Redirect("Admin/Dashboard");
        }
        public async Task<ActionResult> AddAccountToRole(AppRole appRole)
        {
            string userId = appRole.UserId;
            string roleName = "Student";
            var result = await userManager.AddToRolesAsync(userId, roleName);
            if (result.Succeeded)
            {
                return ViewBag.Message = "Add Role Successful!";
            }
            else
            {
                return ViewBag.Message = "Add Role Fail!";
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public Task<ActionResult> Login(AccountViewModel accountVM)
        //{
        //    string username = accountVM.UserName;
        //    string password = accountVM.Password;
        //    var account = await userManager.FindAsync(username, password);
        //    if (account != null)
        //    {
        //        signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
        //        await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
        //        ViewBag.Message = "Login successful!";
        //        return Redirect("~/Admin/Dashboard");
        //    }
        //    else
        //    {
        //        return View("Login");
        //    }
        //}
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var data = db.Users.Where(s => s.UserName.Equals(username));
                if (data.Count() > 0)
                {
                    //add session
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    Session["Password"] = data.FirstOrDefault().PasswordHash;

                    return Redirect("/Admin/Dashboard");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Account/Login");
        }

        public ActionResult AddUser()
        {
            return View();
        }
    }
}