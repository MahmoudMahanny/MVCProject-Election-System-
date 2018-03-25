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
    [Authorize]
    public class VotersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Voters
        
        public ActionResult show()
        {
            System.Threading.Thread.Sleep(1000);
            var model = db.Candidate.ToList();
            return View("_show",model);
        }
        #region ShowWier


        //public ActionResult ShowWier(int id)
        //{  int Maxvotes = 0;
        //    string Name="";
        //    string imgPath = "";

        //    foreach (var can in db.Candidate.ToList())
        //    {   if(Maxvotes==can.NoOfVotes)
        //        {
        //            return RedirectToAction("noresult",new {ID=id });
        //        }
        //        if(can.NoOfVotes>Maxvotes)
        //        {
        //            Maxvotes = can.NoOfVotes;
        //            Name = can.Name;
        //            imgPath = can.ImagePath;
        //        }    
        //    }
        //    canidwinerresult wr = new canidwinerresult {voterID=id,imgPath=imgPath ,Name = Name, Winerresult = Maxvotes };

        //    return View(wr);
        //}
        #endregion
        public ActionResult noresult(int ID)
        {
            return View(ID);
        }
        public ActionResult Index()
        {
            return View(db.Voter.ToList());
        }
        [HttpGet]
        public ActionResult MYPage(string id)
        {
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
            CandidatesIDVoter ca = new CandidatesIDVoter { VoterID = id, canList = db.Candidate.ToList() };
            return View(ca);
        }

        public ActionResult Aplay(int id)
        {

            Voter v = (from vo in db.Voter
                       where vo.ID == id
                       select vo).FirstOrDefault();
           
            Candidate c = new Candidate {ID=v.ID, Name = v.Name, NID = v.NID, BirthDate = v.BirthDate, ImagePath = v.ImagePath };
            if(db.Candidate.ToList().Count==0)
            {
                db.Candidate.Add(c);
                db.SaveChanges();
                return RedirectToAction("Create", "ElectionPrograms", new { CandidateId = c.ID });

            }
            foreach (var item in db.Candidate.ToList())
            {
                if(item.ID==c.ID&& item.IsApplay==true)
                {
                    ElectionPrograms Electionprogram = (from e in db.ElectionProgram
                                                        where e.CID == item.ID
                                                        select e).FirstOrDefault();
                    return RedirectToAction("IsApplayProgram", "ElectionPrograms", new { ElProgID = Electionprogram.ID });

                    
                }
                if (item.ID == c.ID && item.IsApplay == false)
                {
                    return RedirectToAction("Create", "ElectionPrograms", new { CandidateId = c.ID });
                }

            }
            db.Candidate.Add(c);
            db.SaveChanges();
            return RedirectToAction( "Create", "ElectionPrograms", new { CandidateId = c.ID });

        }
        public ActionResult IsVoteMessag(string candidateimagepath, string voterimagPath , int id,string vname,string cname)
        
        {

            //Voter v = (from vo in db.Voter
            //           where vo.ID == id
            //           select vo).FirstOrDefault();
            VoterCandidate votercand = new VoterCandidate {voterID=id,
                votername =vname,candidatename=cname,candidateimagepath=candidateimagepath,
            voterimagPath=voterimagPath};
            return View(votercand);
        }
       
        [HttpGet]
        public ActionResult Vote(string id)
        {

<<<<<<< HEAD
            var v = (from vo in db.Users
                       where vo.Id == id
=======
            Voter v1 = (from vo in db.Voter
                       where vo.ID == id
>>>>>>> 836fe1cdc0cb73774001f29a3b4ead509b858b36
                       select vo).FirstOrDefault();
            Candidate c1 = db.Candidate.Find(v1.CandidateID);
            VoterCandidate vc1 =new VoterCandidate {voterID=v1.ID, votername=v1.Name,voterimagPath=v1.ImagePath,
             candidatename=c1.Name,candidateimagepath=c1.ImagePath};
            if (v1.IsVote == true)
            {
                return RedirectToAction("IsVoteMessag", new {
                    candidateimagepath=c1.ImagePath,
                    voterimagPath =v1.ImagePath, id=v1.ID, vname = v1.Name,cname=c1.Name });
            }


            CandidatesIDVoter ca = new CandidatesIDVoter { VoterID = id, canList = db.Candidate.ToList() };



                return View(ca);
            
        }
        [HttpPost]
        public ActionResult change(int id, int VoterID)
        {

            Voter v = db.Voter.Find(VoterID);
            Candidate ca = db.Candidate.Find(id);
           
           
                ca.NoOfVotes += 1;
                v.IsVote = true;
<<<<<<< HEAD
                 v.CandidateID = ca.ID;
                 CandidateVoter cv = new CandidateVoter { candidate_id = id, Voter_id = VoterID };
=======
                CandidateVoter cv = new CandidateVoter { candidate_id = ca.ID, Voter_id = v.ID };
>>>>>>> 73a3ae920ba22808a8fc5074d785fa93062bce4d
                db.CandidateVoter.Add(cv);
                db.SaveChanges();

                return RedirectToAction("MYPage", new { id = VoterID });
            
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



        public ActionResult ShowResult()
        {
            return View(db.Candidate.ToList());
        }

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
