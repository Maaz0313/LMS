using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Edubin.Models;

namespace Edubin.Controllers
{   [AllowAnonymous]
    public class AccountsController : Controller
    {
        // GET: Accounts
        
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User reg) /*using User table*/
        {
            using (var context = new EdubinEntities())
            {
                context.Users.Add(reg);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model) /*using UserModel model class*/
        {
            using (var context = new EdubinEntities())
            {
                bool isValid = context.Users.Any(x => x.UserName == model.UserName && x.UserPassword == model.UserPassword);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View();
        }
        public ActionResult LogOut() /*Don't create its View*/
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult F_Dashboard() //dashboard for Faculty
        {

            return View();
        }
        [HttpPost]
        public ActionResult S_Dashboard(User S_modelgedin) //dashboard for Student
        {
            //using (var context = new EdubinEntities())
            //{
            //    bool isValid = context.Users.Any(x => x.Username == S_modelgedin.Username && x.Passwords == S_modelgedin.Passwords);
            //    if (isValid)
            //    {
            //        FormsAuthentication.SetAuthCookie(S_modelgedin.Username, false);
            //        return RedirectToAction("Index", "Student_Details");
            //    }
            //    ModelState.AddModelError("", "Invalid username or password");
            //}
            return View();
        }
    }
}