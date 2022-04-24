using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

namespace SurveyEducation.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext(() => new MyDbContext());
            //app.CreatePerOwinContext<UserManager>(UserManager.Create);
            //app.CreatePerOwinContext<RoleManager>(AppRoleManager.Create);
            //app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Account/Login"),
            });

        }
    }
}