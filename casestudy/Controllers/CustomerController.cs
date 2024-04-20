using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using casestudy.Models;

namespace casestudy.Controllers
{
    public class CustomerController : Controller
    {
        FinalCaseStudyEntities db = new FinalCaseStudyEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult StudentLogin(StudentLogin login)

        {

            var StudentLogin = db.StudentLogins.Where(x => x.UserID == login.UserID && x.Username == login.Username && x.Password == login.Password).Count();

            if (StudentLogin > 0)

            {

                return Redirect("StudentDashboard");

            }

            else

            {

                return View();

            }

        }



        public ActionResult StudentDashboard()

        {

            return View();

        }
    }
}