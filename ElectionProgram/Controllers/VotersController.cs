using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectionProgram.Models;
using ElectionProgram.ViewModel;
using ElectionProgram.ViewModel;
using Microsoft.AspNet.Identity;

namespace ElectionProgram.Controllers
{
    [Authorize]
    public class VotersController : Controller
    {
        string ApplicationUserID;
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Voters
        public ActionResult Index()
        {
            return View(db.Voter.ToList());
        }
        [HttpGet]
        public ActionResult MYPage(string id)
        {
            ApplicationUserID = id;
        ApplicationUser User = (from vo in db.Users
                       where vo.Id == id
                       select vo).FirstOrDefault();
            return View(User);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ShowCandidate(string id)
        {
            CandidatesVoter ca = new CandidatesVoter { VoterID = id, canList = db.Candidate.ToList() };
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
        public ActionResult IsVoteMessag(string id)
        {

            ApplicationUser AppUser = (from vo in db.Users
                                       where vo.Id == id
                                       select vo).FirstOrDefault();
            return View(AppUser);
        }
       
        [HttpGet]
        public ActionResult Vote(string id)
        {

            ApplicationUser AppUser = (from vo in db.Users
                       where vo.Id == id
                       select vo).FirstOrDefault();
            if (AppUser.IsVote == true)
            {
                return RedirectToAction("IsVoteMessag", new { ID = id });
            }
            else
            {
                CandidatesVoter ca = new CandidatesVoter { VoterID = id, canList = db.Candidate.ToList() };
                return View(ca);
            }

        }
        [HttpPost]
        public ActionResult Vote(int CandidateId,string VoterID)
        {
            
            ApplicationUser AppUser = (from APPUSER in db.Users
                       where APPUSER.Id == VoterID
                       select APPUSER).FirstOrDefault();
            if (AppUser.IsVote == true)
            {
                return RedirectToAction("MYPage", new { id = VoterID });
            }
            else
            {
                var candidate = (from c in db.Candidate
                          where c.ID == CandidateId
                          select c).FirstOrDefault();
                candidate.NoOfVotes += 1;
                AppUser.IsVote = true;
                CandidateVoter cv = new CandidateVoter { candidate_id = candidate.ID, ApplicationUserID = AppUser.Id };
                db.CandidateVoter.Add(cv);
                db.SaveChanges();

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

        public ActionResult Create([Bind(Include = "ID,Name,BirthDate,Gender,NID,Address,Phone,CareerPosition,ImagePath")] Voter voter, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = HttpContext.Server.MapPath("~/Content/images/");
                    file.SaveAs(path + file.FileName);

                    voter.ImagePath = "/Content/images/" + file.FileName;
                }

                db.Voter.Add(voter);
                db.SaveChanges();
                return RedirectToAction("MYPage", new { id = voter.ID });
            }
            else
            {
                return View(voter);
            }
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
        public ActionResult Edit([Bind(Include = "ID,Name,BirthDate,Gender,NID,Address,Phone,CareerPosition,ImagePath")] Voter voter, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(voter).State = EntityState.Modified;
                if (file != null)
                {
                    string path = HttpContext.Server.MapPath("~/Content/images/");
                    file.SaveAs(path + file.FileName);

                    voter.ImagePath = "/Content/images/" + file.FileName;
                }
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

        [HttpGet]
        public ActionResult ShowResult(string ID)
        {
            
            Election ele = (from e in db.Election
                            select e).FirstOrDefault();
            var AppuserID = User.Identity.GetUserId();
            CandidatesVoter electionCandidate = new CandidatesVoter()
            {
                ElectionId = ele.ID,
                canList = db.Candidate.ToList(),
                VoterID = ID
            };

            if (ele.EndDate < System.DateTime.Now)
            {
                return View(electionCandidate);
            }
            else
            {
                return RedirectToAction("ShowWinner");
            }
        }
        //[HttpPost]
        //public ActionResult ShowResult(ElectionCadidates electionCandidate)
        //{

        //    Election e = (from ele in db.Election
        //                  where ele.ID == electionCandidate.ElectionId
        //                  select ele).FirstOrDefault();

        //    if (e.EndDate<System.DateTime.Now)
        //    {
        //        return View(electionCandidate);
        //    }
        //    else
        //    {
        //        return RedirectToAction("ShowWinner");
        //    }
        //}

        public ActionResult ShowWinner()
        {
            var Top2Candidate = (from c in db.Candidate
                                 select c).OrderByDescending(c => c.NoOfVotes).Take(2).ToList();

            if (Top2Candidate[0].NoOfVotes == Top2Candidate[1].NoOfVotes)
            {
                return RedirectToAction("RepeatedElection");

            }
            //else if (Top2Candidate[0].NoOfVotes > Top2Candidate[1].NoOfVotes)
           
            //    return View(Top2Candidate[0]);
            
            return View(Top2Candidate[0]);
        }
        public ActionResult RepeatedElection()
        {
            var Top2Candidate = (from c in db.Candidate
                                 select c).OrderByDescending(c => c.NoOfVotes).Take(2).ToList();
            return View(Top2Candidate);
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
