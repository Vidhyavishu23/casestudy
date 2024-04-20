using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using casestudy;
using casestudy.Models;


namespace casestudy.Controllers
{
    public class HomeController : Controller
    {
        FinalCaseStudyEntities db = new FinalCaseStudyEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Admin(Admin Login)
        {
            var Admin = db.Admins.Where(x => x.Username == Login.Username && x.Password == Login.Password).Count();
            if (Admin > 0)
            {
                return Redirect("AdminDashboard");
            }
            else
            {
                return View();
            }
        }
      public ActionResult AdminDashboard()
        {
            return View();
        }


    }
    }
