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
    public class ElectionProgramsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ElectionPrograms
        public ActionResult Index()
        {
            return View(db.ElectionProgram.ToList());
        }

        // GET: ElectionPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectionPrograms electionProgram = db.ElectionProgram.Find(id);
            if (electionProgram == null)
            {
                return HttpNotFound();
            }
            return View(electionProgram);
        }

        // GET: ElectionPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElectionPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Slogan,Program,Symbol,ProgramStartDate,ProgramEndDate")] Models.ElectionPrograms electionProgram)
        {
            if (ModelState.IsValid)
            {
                db.ElectionProgram.Add(electionProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(electionProgram);
        }

        // GET: ElectionPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectionPrograms electionProgram = db.ElectionProgram.Find(id);
            if (electionProgram == null)
            {
                return HttpNotFound();
            }
            return View(electionProgram);
        }

        // POST: ElectionPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Slogan,Program,Symbol,ProgramStartDate,ProgramEndDate")] Models.ElectionPrograms electionProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electionProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(electionProgram);
        }

        // GET: ElectionPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectionPrograms electionProgram = db.ElectionProgram.Find(id);
            if (electionProgram == null)
            {
                return HttpNotFound();
            }
            return View(electionProgram);
        }

        // POST: ElectionPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ElectionPrograms electionProgram = db.ElectionProgram.Find(id);
            db.ElectionProgram.Remove(electionProgram);
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
