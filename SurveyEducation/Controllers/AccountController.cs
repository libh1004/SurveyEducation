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
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

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
            Console.WriteLine(user.Id);
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
                    Name = Models.RoleValue.Student
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
                    Name = Models.RoleValue.FacultyOrStaff
                };
                var result2 = await roleManager.CreateAsync(roleFacultyStaff);
                if (result2.Succeeded)
                {
                    return Redirect("~/Home");
                }
                else
                {
                    return ViewBag.Message = "Add Role Fail!";
                }
               
            }
            return Redirect("~/Home");
        }
          
        //public async Task<ActionResult> AddAccountToRole(AppRole appRole)
        //{
        //    var userId = await userManager.FindByIdAsync(User.Identity.GetUserId());
        //    string roleName = "Student";
        //    var result = await userManager.AddToRolesAsync(userId, roleName);
        //    if (result.Succeeded)
        //    {
        //        return ViewBag.Message = "Add Role Successful!";
        //    }
        //    else
        //    {
        //        return ViewBag.Message = "Add Role Fail!";
        //    }
        //}
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                
                var data = db.Users.Where(s => s.UserName.Equals(username)).FirstOrDefault();
                if (data == null)
                {
                    // user ko ton tai
                    return RedirectToAction("Login");
                }
                var passwordHasher = new PasswordHasher();
                
                if (passwordHasher.VerifyHashedPassword(data.PasswordHash, password) == PasswordVerificationResult.Failed)
                {
                    // sai pass
                    return RedirectToAction("Login");
                }
                Session["UserName"] = new
                {
                    username = data.UserName,
                    id = data.Id
                };

                return Redirect("/Home/Index");
            }
            return View("Login");
        }
        

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}