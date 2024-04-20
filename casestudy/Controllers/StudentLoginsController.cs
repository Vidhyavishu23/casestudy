using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using casestudy.Models;

namespace casestudy.Controllers
{
    public class StudentLoginsController : Controller
    {
        private FinalCaseStudyEntities db = new FinalCaseStudyEntities();

        // GET: StudentLogins
        public ActionResult Index()
        {
            // return View(db.StudentLogins.ToList());
            return Redirect("/StudentLogins/Create");
        }

        // GET: StudentLogins/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StudentLogin studentLogin = db.StudentLogins.Find(id);
        //    if (studentLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(studentLogin);
        //}

        // GET: StudentLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Firstname,Lastname,Username,Phone,Email,Password")] StudentLogin studentLogin)
        {
            if (ModelState.IsValid)
            {
                db.StudentLogins.Add(studentLogin);
                db.SaveChanges();
                return Redirect("/Customer/StudentLogin");
            }

            return View(studentLogin);
        }

        // GET: StudentLogins/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StudentLogin studentLogin = db.StudentLogins.Find(id);
        //    if (studentLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(studentLogin);
        //}

        // POST: StudentLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserID,Firstname,Lastname,Username,Phone,Email,Password")] StudentLogin studentLogin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(studentLogin).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(studentLogin);
        //}

        //// GET: StudentLogins/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StudentLogin studentLogin = db.StudentLogins.Find(id);
        //    if (studentLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(studentLogin);
        //}

        // POST: StudentLogins/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    StudentLogin studentLogin = db.StudentLogins.Find(id);
        //    db.StudentLogins.Remove(studentLogin);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
