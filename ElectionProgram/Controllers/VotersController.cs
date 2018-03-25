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
        public ActionResult Vote(int id)
        {

            Voter v1 = (from vo in db.Voter
                       where vo.ID == id
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
                 v.CandidateID = ca.ID;
                 CandidateVoter cv = new CandidateVoter { candidate_id = id, Voter_id = VoterID };
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
