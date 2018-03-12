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
    public class ElectionSymbolsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ElectionSymbols
        public ActionResult Index()
        {
            return View(db.electionSymbols.ToList());
        }

        // GET: ElectionSymbols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectionSymbols electionSymbols = db.electionSymbols.Find(id);
            if (electionSymbols == null)
            {
                return HttpNotFound();
            }
            return View(electionSymbols);
        }

        // GET: ElectionSymbols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElectionSymbols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,symbol")] ElectionSymbols electionSymbols)
        {
            if (ModelState.IsValid)
            {
                db.electionSymbols.Add(electionSymbols);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(electionSymbols);
        }

        // GET: ElectionSymbols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectionSymbols electionSymbols = db.electionSymbols.Find(id);
            if (electionSymbols == null)
            {
                return HttpNotFound();
            }
            return View(electionSymbols);
        }

        // POST: ElectionSymbols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,symbol")] ElectionSymbols electionSymbols)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electionSymbols).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(electionSymbols);
        }

        // GET: ElectionSymbols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectionSymbols electionSymbols = db.electionSymbols.Find(id);
            if (electionSymbols == null)
            {
                return HttpNotFound();
            }
            return View(electionSymbols);
        }

        // POST: ElectionSymbols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ElectionSymbols electionSymbols = db.electionSymbols.Find(id);
            db.electionSymbols.Remove(electionSymbols);
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
