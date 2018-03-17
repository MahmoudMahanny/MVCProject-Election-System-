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
    public class QuestionairesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Questionaires
        public ActionResult Index()
        {
            return View(db.Questionaire.ToList());
        }

        // GET: Questionaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionaire questionaire = db.Questionaire.Find(id);
            if (questionaire == null)
            {
                return HttpNotFound();
            }
            //var questionList = (from quest in db.Question
            //               where quest.QuestionaireID == id
            //               select quest.question).ToList();
            return View(questionaire);
        }

        // GET: Questionaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questionaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] Questionaire questionaire, string Question1, string Question2, string Question3, string Question4, string Question5)
        {
            if (ModelState.IsValid)
            {
                db.Questionaire.Add(questionaire);
                List<Question> questions = new List<Question>()
                {
                    new Question() {question=Question1,QuestionaireID= questionaire.ID },
                    new Question() {question=Question2,QuestionaireID= questionaire.ID },
                    new Question() {question=Question3,QuestionaireID= questionaire.ID },
                    new Question() {question=Question4,QuestionaireID= questionaire.ID },
                    new Question() {question=Question5,QuestionaireID= questionaire.ID }
                };

                db.Question.AddRange(questions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionaire);
        }

        // GET: Questionaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionaire questionaire = db.Questionaire.Find(id);
            if (questionaire == null)
            {
                return HttpNotFound();
            }
            return View(questionaire);
        }

        // POST: Questionaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] Questionaire questionaire, string Question_1, string Question_2, string Question_3, string Question_4, string Question_5)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionaire).State = EntityState.Modified;
                //var questions = (from q in db.Question
                //                 where q.QuestionaireID == questionaire.ID
                //                 select q.question).ToList();
                //List<string> qust = new List<string>()
                //{
                //Question_1,Question_2,Question_3,Question_4,Question_5
                //};
                //int counter = -1;
                //foreach (string item in questions)
                //{
                //    counter++;
                //    Question_1 = item;
                //}
               
                    List<Question> que = new List<Question>();
                    que=db.Question.Where(q => q.QuestionaireID == questionaire.ID).ToList();
                    
               foreach(var item in que)
                {
                 
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(questionaire);
    }
        // GET: Questionaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionaire questionaire = db.Questionaire.Find(id);
            if (questionaire == null)
            {
                return HttpNotFound();
            }
            return View(questionaire);
        }

        // POST: Questionaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questionaire questionaire = db.Questionaire.Find(id);
            db.Questionaire.Remove(questionaire);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult ShowQuestions()
        //{
        //    var Questionaires =(from q in db.Questionaire
        //                        where q.Type == "Candidate"
        //                        select q.ID).ToList();
        //    foreach (var item in Questionaires)
        //    {
        //        var Questions = from q in db.Question
        //                            where q.QuestionaireID==5
        //                            select q.question;
               
        //    }

        //    return View();
        //}

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
