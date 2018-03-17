using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectionProgram.Models;
using ElectionProgram.ShowModel;


namespace ElectionProgram.Controllers
{
    public class VotersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Voters
        public ActionResult Index()
        {
            return View(db.Voter.ToList());
        }
        [HttpGet]
        public ActionResult MYPage(int id)
        {
            Voter v = (from vo in db.Voter
                       where vo.ID == id
                       select vo).FirstOrDefault();
            return View(v);
        }
        [HttpGet]
        public ActionResult ShowCandidate(int id)
        {
            CandidatesIDVoter ca = new CandidatesIDVoter { VoterID = id, canList = db.Candidate.ToList() };
            return View(ca);
        }

        public ActionResult Aplay(int id)
        {

            Voter v = (from vo in db.Voter
                       where vo.ID == id
                       select vo).FirstOrDefault();
            db.Voter.Remove(v);
            Candidate c = new Candidate { Name = v.Name, NID = v.NID, BirthDate = v.BirthDate, ImagePath = v.ImagePath };
            db.Candidate.Add(c);
            db.SaveChanges();
            return RedirectToAction("Details", "Candidates", new { ID = c.ID });

        }
        public ActionResult IsVoteMessag(int id)
        {

            Voter v = (from vo in db.Voter
                       where vo.ID == id
                       select vo).FirstOrDefault();
            return View(v);
        }
       
             public ActionResult Aplay(int id)
        {

            Voter v = (from vo in db.Voter
                       where vo.ID == id
                       select vo).FirstOrDefault();
            db.Voter.Remove(v);
            Candidate c = new Candidate { Name = v.Name, NID = v.NID, BirthDate = v.BirthDate ,ImagePath=v.ImagePath };
            db.Candidate.Add(c);
            db.SaveChanges();
            return RedirectToAction("Details", "Candidates", new { ID = c.ID });
           
        }
        public ActionResult IsVoteMessag(int id)
        {

            Voter v = (from vo in db.Voter
                       where vo.ID == id
                       select vo).FirstOrDefault();
            return View(v);
        }
        [HttpGet]
        public ActionResult Vote(int id)
        {

            Voter v = (from vo in db.Voter
                       where vo.ID == id
                       select vo).FirstOrDefault();
            if (v.IsVote == true)
            {
                return RedirectToAction("IsVoteMessag", new { ID = id });
            }
            else
            {

                CandidatesIDVoter ca = new CandidatesIDVoter { VoterID = id, canList = db.Candidate.ToList() };



                return View(ca);
            }
        }
        [HttpPost]
        public ActionResult change(int id,int VoterID)
        {
            
            Voter v = (from vo in db.Voter
                       where vo.ID == VoterID
                       select vo).FirstOrDefault();
            if (v.IsVote == true)
            {
                return RedirectToAction("MYPage", new { id = VoterID });
                
            }
            else
            {
                var ca = (from c in db.Candidate
                          where c.ID == id
                          select c).FirstOrDefault();
                ca.NoOfVotes += 1;
                v.IsVote = true;
                CandidateVoter cv = new CandidateVoter { candidate_id = id, Voter_id = VoterID };
                db.CandidateVoter.Add(cv);
                db.SaveChanges();
<<<<<<< HEAD
=======



>>>>>>> 220797f3fcab6a85c4958c31b51d30c86ffa1e13
                return RedirectToAction("MYPage", new { id = VoterID });
            }
        }


        // GET: Voters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voter.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // GET: Voters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ID,Name,BirthDate,Gender,NID,Address,Phone,CareerPosition,PIC")] Voter voter, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = HttpContext.Server.MapPath("~/Content/images/");
                    file.SaveAs(path + file.FileName);

                    voter.ImagePath ="/Content/images/"+ file.FileName;
                }
            }
            db.Voter.Add(voter);
            db.SaveChanges();
            return RedirectToAction("MYPage", new { id = voter.ID });
        }
        

        // GET: Voters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voter.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // POST: Voters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BirthDate,Gender,NID,Address,Phone,CareerPosition,PIC")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voter);
        }
        // GET: Voters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voter.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // POST: Voters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 

            Voter voter = db.Voter.Find(id);
            db.Voter.Remove(voter);
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
