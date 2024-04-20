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
    public class StudentsController : Controller
    {
        private FinalCaseStudyEntities db = new FinalCaseStudyEntities();

        // GET: Students
        public ActionResult Index()
        {
            var studentLogins = db.StudentLogins.Include(s => s.Class).Include(s => s.Student).Include(s => s.Fee).Include(s => s.Admission);
            return View(studentLogins.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLogin studentLogin = db.StudentLogins.Find(id);
            if (studentLogin == null)
            {
                return HttpNotFound();
            }
            return View(studentLogin);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username");
            ViewBag.FeeID = new SelectList(db.Fees, "FeeID", "FeeID");
            ViewBag.AdmissionID = new SelectList(db.Admissions, "AdmissionID", "AdmissionID");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Firstname,Lastname,Username,Phone,Email,Password,ClassID,StudentID,FeeID,AdmissionID")] StudentLogin studentLogin)
        {
            if (ModelState.IsValid)
            {
                db.StudentLogins.Add(studentLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", studentLogin.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", studentLogin.StudentID);
            ViewBag.FeeID = new SelectList(db.Fees, "FeeID", "FeeID", studentLogin.FeeID);
            ViewBag.AdmissionID = new SelectList(db.Admissions, "AdmissionID", "AdmissionID", studentLogin.AdmissionID);
            return View(studentLogin);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLogin studentLogin = db.StudentLogins.Find(id);
            if (studentLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", studentLogin.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", studentLogin.StudentID);
            ViewBag.FeeID = new SelectList(db.Fees, "FeeID", "FeeID", studentLogin.FeeID);
            ViewBag.AdmissionID = new SelectList(db.Admissions, "AdmissionID", "AdmissionID", studentLogin.AdmissionID);
            return View(studentLogin);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Firstname,Lastname,Username,Phone,Email,Password,ClassID,StudentID,FeeID,AdmissionID")] StudentLogin studentLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", studentLogin.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Username", studentLogin.StudentID);
            ViewBag.FeeID = new SelectList(db.Fees, "FeeID", "FeeID", studentLogin.FeeID);
            ViewBag.AdmissionID = new SelectList(db.Admissions, "AdmissionID", "AdmissionID", studentLogin.AdmissionID);
            return View(studentLogin);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLogin studentLogin = db.StudentLogins.Find(id);
            if (studentLogin == null)
            {
                return HttpNotFound();
            }
            return View(studentLogin);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentLogin studentLogin = db.StudentLogins.Find(id);
            db.StudentLogins.Remove(studentLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
