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
<<<<<<< HEAD
    { 
        private DataContext db = new DataContext();
=======
    {
        private ApplicationDbContext db = new ApplicationDbContext();
>>>>>>> 73a3ae920ba22808a8fc5074d785fa93062bce4d

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
        [HttpGet]
        public ActionResult Create(int CandidateId)
        {
            var candidate = (from ca in db.Candidate
                             where ca.ID == CandidateId
                             select ca).FirstOrDefault();
            //if(candidate.IsApplay==true)
            //{
            //    ElectionPrograms Electionprogram = (from e in db.ElectionProgram
            //                                        where e.CID == candidate.ID
            //                                        select e).FirstOrDefault();
            //    return RedirectToAction("IsApplayProgram", new { ElProgID = Electionprogram.ID });
            //}
            ElectionPrograms el = new ElectionPrograms { CID = CandidateId,Can=candidate};
            candidate.IsApplay = true;
            db.SaveChanges();
            return View(el);
        }


        public ActionResult IsApplayProgram(int ElProgID)
        {
            ElectionPrograms Electionprogram = (from e in db.ElectionProgram
                                                where e.ID==ElProgID
                                                select e).FirstOrDefault();
            ElectionPrograms Electionpr =Electionprogram;
           
            return View(Electionpr);
        }















        // POST: ElectionPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "ID,Name,Slogan,Program,Symbol,ProgramStartDate,ProgramEndDate")] Models.*/ElectionPrograms electionProgram)
        {
            if (ModelState.IsValid)
            {
                ElectionPrograms El = new ElectionPrograms
                {
                    ID = electionProgram.ID,
                    Name = electionProgram.Name,
                    Slogan = electionProgram.Slogan,
                    Program = electionProgram.Program,
                    
                    ProgramEndDate = electionProgram.ProgramEndDate,
                    ProgramStartDate = electionProgram.ProgramStartDate,
                    CID = electionProgram.CID


                };
                var candidate = (from ca in db.Candidate
                                 where ca.ID == electionProgram.CID
                                 select ca).FirstOrDefault();
                El.Symbol = candidate.ImagePath;
                db.ElectionProgram.Add(El);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(electionProgram);
            

            

           // return View(electionProgram);
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
        public ActionResult Edit([Bind(Include = "CID,ID,Name,Slogan,Program,Symbol,ProgramStartDate,ProgramEndDate")] Models.ElectionPrograms electionProgram)
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
