using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Edubin.Controllers
{   
    [AllowAnonymous] //MUST USE
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            
            return View();
        }
        public ActionResult Courses()
        {
            
            return View();
        }
        public ActionResult Events()
        {

            return View();
        }
        public ActionResult Teachers()
        {

            return View();
        }
    }
}