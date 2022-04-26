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
                Status = 0,
                Email = accountVM.Email,
                EmployeeNumber = accountVM.EmployeeNumber,
                DisabledAt = DateTime.Now,
                AddmissionDate = DateTime.Now,
                DateOfJoining = DateTime.Now
            };
            var result = await userManager.CreateAsync(user, accountVM.Password);
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
            AppRole role = new AppRole()
            {
                Name = "Student"
            };
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return ViewBag.Message = "Add Role Successful!";
            }
            else
            {
                return ViewBag.Message = "Add Role Fail!";
            }
        }
        public async Task<ActionResult> AddAccountToRole(AppRole appRole)
        {
            string userId = appRole.UserId;
            string roleName = "";
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
        [HttpPost]
        public async Task<ActionResult> Login(AccountViewModel accountVM)
        {
            string username = accountVM.UserName;
            string password = accountVM.Password;
            var account = await userManager.FindAsync(username, password);
            if (account != null)
            {
                signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
                await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
                ViewBag.Message = "Login successful!";
                return Redirect("~/Admin/Dashboard");
            }
            else
            {
                return View("Login");
            }
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