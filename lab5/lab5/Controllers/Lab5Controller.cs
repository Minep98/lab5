using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab5.Models;

namespace lab5.Controllers
{
    public class Lab5Controller : Controller
    {
        private Lab5Entities db = new Lab5Entities();

        // GET: Lab5
        public ActionResult Index()
        {
            return View(db.Lab5.ToList());
        }

        // GET: Lab5/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab5 lab5 = db.Lab5.Find(id);
            if (lab5 == null)
            {
                return HttpNotFound();
            }
            return View(lab5);
        }

        // GET: Lab5/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lab5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,first_name,last_name,email,gender,ip_address")] Lab5 lab5)
        {
            if (ModelState.IsValid)
            {
                db.Lab5.Add(lab5);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lab5);
        }

        // GET: Lab5/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab5 lab5 = db.Lab5.Find(id);
            if (lab5 == null)
            {
                return HttpNotFound();
            }
            return View(lab5);
        }

        // POST: Lab5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,email,gender,ip_address")] Lab5 lab5)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lab5).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lab5);
        }

        // GET: Lab5/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab5 lab5 = db.Lab5.Find(id);
            if (lab5 == null)
            {
                return HttpNotFound();
            }
            return View(lab5);
        }

        // POST: Lab5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lab5 lab5 = db.Lab5.Find(id);
            db.Lab5.Remove(lab5);
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
