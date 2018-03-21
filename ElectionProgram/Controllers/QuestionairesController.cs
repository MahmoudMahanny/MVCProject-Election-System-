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

namespace ElectionProgram.Controllers
{
    public class QuestionairesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Questionaires
        public ActionResult Index()
        {
            if (db.Questionaire.Count() == 0)
            {

                Questionaire QCandidate = new Questionaire() { Type = "Candidate" };
                Questionaire QCopmany = new Questionaire() { Type = "Company" };
                db.Questionaire.Add(QCandidate);
                db.Questionaire.Add(QCopmany);
                db.SaveChanges();
            }
            else
            {
                var query = (from q in db.Questionaire
                             where q.Type == "Company"
                             select q).FirstOrDefault();
                if (query == null)
                {
                    Questionaire QCopmany = new Questionaire() { Type = "Company" };
                    db.Questionaire.Add(QCopmany);
                    db.SaveChanges();
                }

                var que = (from q in db.Questionaire
                           where q.Type == "Candidate"
                           select q).FirstOrDefault();
                if (que == null)

                {
                    Questionaire QCandidate = new Questionaire() { Type = "Candidate" };
                    db.Questionaire.Add(QCandidate);
                    db.SaveChanges();
                }
            }

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
            if (db.Questionaire.Count() == 0)
            {

                Questionaire QCandidate = new Questionaire() { Type = "Candidate" };
                Questionaire QCopmany = new Questionaire() { Type = "Company" };
                db.Questionaire.Add(QCandidate);
                db.Questionaire.Add(QCopmany);
                db.SaveChanges();
            }
            else
            {
                var query = (from q in db.Questionaire
                             where q.Type == "Company"
                             select q).FirstOrDefault();
                if (query == null)
                {
                    Questionaire QCopmany = new Questionaire() { Type = "Company" };
                    db.Questionaire.Add(QCopmany);
                    db.SaveChanges();
                }

                var que = (from q in db.Questionaire
                           where q.Type == "Candidate"
                           select q).FirstOrDefault();
                if (que == null)

                {
                    Questionaire QCandidate = new Questionaire() { Type = "Candidate" };
                    db.Questionaire.Add(QCandidate);
                    db.SaveChanges();
                }
            }

            return View();
        }

        // POST: Questionaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] Questionaire questionaire, string QuestionaireType, string Question1, string Question2, string Question3, string Question4, string Question5)
        {
            if (ModelState.IsValid)
            {


                var Questionaire = (from q in db.Questionaire
                                    where q.Type == QuestionaireType
                                    select q).FirstOrDefault();
                //questionaire.Type = QuestionaireType;
                //  db.Questionaire.Add(questionaire);
                List<Question> questions = new List<Question>();
                //{
                //    new Question() {question=Question1,QuestionaireID= Questionaire.ID },
                //    new Question() {question=Question2,QuestionaireID= Questionaire.ID },
                //    new Question() {question=Question3,QuestionaireID= Questionaire.ID },
                //    new Question() {question=Question4,QuestionaireID= Questionaire.ID },
                //    new Question() {question=Question5,QuestionaireID= Questionaire.ID }
                //};
                if (Question1 != "")
                {
                    Question que = new Question() { question = Question1, QuestionaireID = Questionaire.ID };
                    questions.Add(que);
                    // db.SaveChanges();

                }
                if (Question2 != "")
                {
                    Question que = new Question() { question = Question2, QuestionaireID = Questionaire.ID };
                    questions.Add(que);
                    // db.SaveChanges();

                }
                if (Question3 != "")
                {
                    Question que = new Question() { question = Question3, QuestionaireID = Questionaire.ID };
                    questions.Add(que);
                    //  db.SaveChanges();

                }
                if (Question4 != "")
                {
                    Question que = new Question() { question = Question4, QuestionaireID = Questionaire.ID };
                    questions.Add(que);
                    //db.SaveChanges();

                }
                if (Question5 != "")
                {
                    Question que = new Question() { question = Question5, QuestionaireID = Questionaire.ID };
                    questions.Add(que);
                    //db.SaveChanges();

                }
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
                // db.Entry(questionaire).State = EntityState.Modified;
                // questionaire.Type = QuestionaireType;
                var questions = (from q in db.Question
                                 where q.QuestionaireID == questionaire.ID
                                 select q).ToList();
                db.Question.RemoveRange(questions);
                db.SaveChanges();
                List<Question> qust = new List<Question>();
                //{

                //    new Question() { question = Question_1, QuestionaireID = questionaire.ID },
                //    new Question() { question = Question_2, QuestionaireID = questionaire.ID },
                //    new Question() { question = Question_3, QuestionaireID = questionaire.ID },
                //    new Question() { question = Question_4, QuestionaireID = questionaire.ID },
                //    new Question() { question = Question_5, QuestionaireID = questionaire.ID }
                //};

                if (Question_1 != "")
                {
                    Question que = new Question() { question = Question_1, QuestionaireID = questionaire.ID };
                    qust.Add(que);
                    //db.SaveChanges();

                }
                if (Question_2 != "")
                {
                    Question que = new Question() { question = Question_2, QuestionaireID = questionaire.ID };
                    qust.Add(que);
                    //db.SaveChanges();

                }
                if (Question_3 != "")
                {
                    Question que = new Question() { question = Question_3, QuestionaireID = questionaire.ID };
                    qust.Add(que);
                    // db.SaveChanges();

                }
                if (Question_4 != "")
                {
                    Question que = new Question() { question = Question_4, QuestionaireID = questionaire.ID };
                    qust.Add(que);
                    // db.SaveChanges();

                }
                if (Question_5 != "")
                {
                    Question que = new Question() { question = Question_5, QuestionaireID = questionaire.ID };
                    qust.Add(que);
                    //db.SaveChanges();

                }
                db.Question.AddRange(qust);
                db.SaveChanges();

                var delEmptyQue = (from q in db.Question
                                   where q.question == null
                                   select q).ToList();
                db.Question.RemoveRange(delEmptyQue);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(questionaire);
        }
        public ActionResult ShowSurveyResult(int id)
        {
            Questionaire qu = new Questionaire() { ID = id };
            int sum=0;
            float avgSum = 0;
            int NoOfQue;
            float avgOfQue;
            List<float> avgoOfQuestions = new List<float>();
            float serveyResult;
            SurveyAnswer surveyanswer = new SurveyAnswer();
            if (qu.Type=="Company")
            {

                var questions = (from q in db.Question
                             where q.QuestionaireID == qu.ID
                             select q).ToList();
                surveyanswer.Questions.AddRange(questions);
                NoOfQue = surveyanswer.Questions.Count;
                foreach (var item in surveyanswer.Questions)
                {
                    var answers=(from a in db.Answer
                                where a.Question.ID==item.ID
                                select a.answer).ToList();
                    int noOfAnswers = answers.Count;
                    foreach (var ans in answers)
                    {
                        sum += ans;

                    }
                    avgOfQue = sum / noOfAnswers;
                    surveyanswer.avgQuestionAnswer.Add(avgOfQue);
                   // avgoOfQuestions.Add(avgOfQue);
                }
                foreach (float item in surveyanswer.avgQuestionAnswer)
                {   
                    avgSum += item;
                }

                int noOfavgs = surveyanswer.avgQuestionAnswer.Count;
                float totalMark= NoOfQue * 5;

               serveyResult =((avgSum / noOfavgs)/ totalMark)*100;

                if (serveyResult < 50)
                    surveyanswer.Evaluation = "Low Performance";
                else if(serveyResult <65 && serveyResult>=50)
                    surveyanswer.Evaluation = "accepted Performance";
                else if (serveyResult >= 65 && serveyResult <75 )
                    surveyanswer.Evaluation = "Good Performance";
                else if (serveyResult >=75 && serveyResult < 85)
                    surveyanswer.Evaluation = " Very Good Performance";
                else if (serveyResult >=85 && serveyResult <= 100)
                    surveyanswer.Evaluation = "Excellent Performance";
                
            }
            else if (qu.Type == "Candidate")
            {
                var questions = (from q in db.Question
                                 where q.QuestionaireID == qu.ID
                                 select q).ToList();
                surveyanswer.Questions.AddRange(questions);
                NoOfQue = questions.Count;
                foreach (var item in questions)
                {
                    var answers = (from a in db.Answer
                                   where a.Question.ID == item.ID
                                   select a.answer).ToList();
                    int noOfAnswers = answers.Count;
                    foreach (var ans in answers)
                    {
                        sum += ans;

                    }
                    avgOfQue = sum / noOfAnswers;
                    surveyanswer.avgQuestionAnswer.Add(avgOfQue);

                    //avgoOfQuestions.Add(avgOfQue);
                }
                foreach (float item in surveyanswer.avgQuestionAnswer)
                {
                    avgSum += item;
                }

                int noOfavgs = surveyanswer.avgQuestionAnswer.Count;
                float totalMark = NoOfQue * 5;

                serveyResult = ((avgSum / noOfavgs) / totalMark) * 100;
                if (serveyResult < 50)
                    surveyanswer.Evaluation = "Low Performance";
                else if (serveyResult < 65 && serveyResult >= 50)
                    surveyanswer.Evaluation = "accepted Performance";
                else if (serveyResult >= 65 && serveyResult < 75)
                    surveyanswer.Evaluation = "Good Performance";
                else if (serveyResult >= 75 && serveyResult < 85)
                    surveyanswer.Evaluation = " Very Good Performance";
                else if (serveyResult >= 85 && serveyResult <= 100)
                    surveyanswer.Evaluation = "Excellent Performance";

            }


            return View(surveyanswer);
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
