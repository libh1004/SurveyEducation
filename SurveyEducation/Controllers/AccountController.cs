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
        public async Task<ActionResult> AddAccount()
        {
            string password = "123@123Aa";
            Account account = new Account()
            {
                UserName = "NguyenVanP"
            };
                //Account user = new Account()
            //{
            //    UserName = accountVM.UserName,
            //    Status = 0,
            //    Email = accountVM.Email,
            //    EmployeeNumber = accountVM.EmployeeNumber,
            //    DisabledAt = DateTime.Now,
            //    AddmissionDate = DateTime.Now,
            //    DateOfJoining = DateTime.Now
            //};
            //var result = await userManager.CreateAsync(user, accountVM.Password);
            var result = await userManager.CreateAsync(account, password);
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
                return View("Successful");
            }
            else
            {
                return View("Fail");
            }
        }
        public async Task<ActionResult> AddAccountToRole()
        {
            string userId = "096ccf0f-baea-4ae4-8c84-e6d7f051f00d";
            string roleName1 = "Admin";
            string roleName2 = "FacultyOrStaff";
            string roleName3 = "Student";
            var result = await userManager.AddToRolesAsync(userId, roleName3);
            if (result.Succeeded)
            {
                return View("Successful");
            }
            else
            {
                return View("Fail");
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