/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserRecordForm.Models;

namespace UserRecordForm.Controllers
{
    public class UserRec1Controller : Controller
    {
        private UserRecordEntities db = new UserRecordEntities();

        // GET: UserRec1
        public ActionResult Index()
        {
            return View(db.UserRecord.ToList());
        }

        // GET: UserRec1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRec1 userRec1 = db.UserRecord.Find(id);
            if (userRec1 == null)
            {
                return HttpNotFound();
            }
            return View(userRec1);
        }

        // GET: UserRec1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRec1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,email,username,password,mnumber,firstName,LastName,address,dropdownCity,dob,age,ssc_total_mark,ssc_obtained_mark,percentage_ssc")] UserRec1 userRec1)
        {
            if (ModelState.IsValid)
            {
                db.UserRecord.Add(userRec1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRec1);
        }

        // GET: UserRec1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRec1 userRec1 = db.UserRecord.Find(id);
            if (userRec1 == null)
            {
                return HttpNotFound();
            }
            return View(userRec1);
        }

        // POST: UserRec1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,email,username,password,mnumber,firstName,LastName,address,dropdownCity,dob,age,ssc_total_mark,ssc_obtained_mark,percentage_ssc")] UserRec1 userRec1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRec1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRec1);
        }

        // GET: UserRec1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRec1 userRec1 = db.UserRecord.Find(id);
            if (userRec1 == null)
            {
                return HttpNotFound();
            }
            return View(userRec1);
        }

        // POST: UserRec1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRec1 userRec1 = db.UserRecord.Find(id);
            db.UserRecord.Remove(userRec1);
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
*/