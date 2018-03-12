using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectionProgram.Models;

namespace ElectionProgram.Controllers
{
    public class ElectionsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Elections
        public ActionResult Index()
        {
            return View(db.Election.ToList());
        }

        // GET: Elections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Election election = db.Election.Find(id);
            if (election == null)
            {
                return HttpNotFound();
            }
            return View(election);
        }

        // GET: Elections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Elections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,StartDate,EndDate")] Election election)
        {
            if (ModelState.IsValid)
            {
                db.Election.Add(election);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(election);
        }

        // GET: Elections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Election election = db.Election.Find(id);
            if (election == null)
            {
                return HttpNotFound();
            }
            return View(election);
        }

        // POST: Elections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,StartDate,EndDate")] Election election)
        {
            if (ModelState.IsValid)
            {
                db.Entry(election).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(election);
        }

        // GET: Elections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Election election = db.Election.Find(id);
            if (election == null)
            {
                return HttpNotFound();
            }
            return View(election);
        }

        // POST: Elections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Election election = db.Election.Find(id);
            db.Election.Remove(election);
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
