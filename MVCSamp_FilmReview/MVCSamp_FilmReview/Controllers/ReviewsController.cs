using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSamp_FilmReview.Models;

namespace MVCSamp_FilmReview.Controllers
{
    public class ReviewsController : Controller
    {
        private ClsFilmContext db = new ClsFilmContext();

        // GET: Reviews
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.Name;
            var reviews = db.Reviews.Include(r => r.FilmForReview).ToList();
            
            foreach (Review rev in reviews)
            {
                int idr = rev.ReviewId;
                List<Comment> comList = db.Comments.Where(i => i.ReviewId == idr).ToList();
                List<int> scoreL = new List<int>();
                foreach (Comment com in comList)
                {
                    scoreL.Add(com.UserScore);
                }
                if (comList.Count != 0)
                {
                    rev.ReviewScore = (scoreL.AsQueryable().Sum()) / comList.Count;
                }
            }
            return View(reviews);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.Name;
            ViewBag.FilmId = new SelectList(db.ClsFilms, "FilmId", "FilmName");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewId,UserId,FilmId,ReviewTitle,PostDate,Description,ReviewScore")] Review review)
        {
            if (ModelState.IsValid)
            {
                review.UserId = User.Identity.Name;
              
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmId = new SelectList(db.ClsFilms, "FilmId", "FilmName", review.FilmId);
            return View(review);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.UserId = User.Identity.Name;
            ViewBag.isban = false;
            List<Comment> comments = db.Comments.ToList();
            foreach(Comment com in comments)
            {
                if(com.IsBlocked == true && User.Identity.Name == com.AuthorId)
                {
                    ViewBag.isban = true;
                }
            }

            List<Comment> comList = db.Comments.Where(i => i.ReviewId == id).ToList();
            Review review = db.Reviews.Find(id);
            //int count = 0;
            int revscore;
            List<int> scolist = new List<int>();
            foreach (Comment item in comList)
            {
                
                CommentReply comrep = new CommentReply();
                List<CommentReply> comrepList = new List<CommentReply>();
                if(db.CommentReplies.Where(i => i.CommentId == item.CommentId).ToList() != null)
                {
                    comrepList = db.CommentReplies.Where(i => i.CommentId == item.CommentId).ToList();
                }
                
                scolist.Add(item.UserScore);
                              

            }
            revscore = scolist.AsQueryable().Sum();
            if (comList.Count != 0)
            {
                review.ReviewScore = revscore / comList.Count;
            }
            //db.Reviews.Add(review);
            //db.SaveChanges();
           


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult CommentReply(int? id, int? commentId)
        {
            ViewBag.id = id;
            ViewBag.commentId = commentId;
            List<Comment> comList = db.Comments.Where(i => i.ReviewId == id).ToList(); //Retrieve all comment with the ReviewId

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Review review = db.Reviews.Find(id);
            review.Comment = comList;
            int rid = review.ReviewId;

            if(review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        [HttpPost]
        public ActionResult CommentReply()
        {
            int id = Convert.ToInt32(Request.Params["ReviewId"]);
            int commentId = Convert.ToInt32(Request.Params["CommentId"]);
            CommentReply comrep = new CommentReply();
            comrep.Content = Request.Params["NewReply"];
            comrep.CommentId = commentId;
            comrep.CommentReplyId = 2;
            comrep.AuthorId = User.Identity.Name;
            comrep.ReviewId = 1;
            comrep.ActorId = id;
            comrep.DirectorId = id;
            comrep.FilmId = 0;
            db.CommentReplies.Add(comrep);
            db.SaveChanges();
            List<Comment> comList = db.Comments.Where(i => i.ReviewId == id).ToList();

            Review review = db.Reviews.Find(id);
            review.Comment = comList;
            int rid = review.ReviewId;

            if(review == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details/" + id);

        }

        [HttpPost]
        public ActionResult Details()
        {
            ViewBag.UserId = User.Identity.Name;
            int id = Convert.ToInt32(Request.Params["ReviewId"]);
            Comment com = new Comment();
            
            com.Content = Request.Params["NewComment"];
            com.UserScore = Convert.ToInt32(Request.Params["UserScore"]);
            com.AuthorId = User.Identity.Name;
            com.ReviewId = id;
            com.ActorId = 1;
            com.DirectorId = 1;
            com.FilmId = 1;
            db.Comments.Add(com);
            db.SaveChanges();
            List<Comment> comList = db.Comments.Where(i => i.ReviewId == id).ToList();
            Review review = db.Reviews.Find(id);

            //int revscore;
            //List<int> scolist = new List<int>();
            foreach (Comment item in comList)
            {
                
                
                CommentReply comrep = new CommentReply(); 
                List<CommentReply> comrepList = new List<CommentReply>();
                if(db.CommentReplies.Where(i => i.CommentId == item.CommentId).ToList() != null)
                {
                    comrepList = db.CommentReplies.Where(i => i.CommentId == item.CommentId).ToList();
                }
                //scolist.Add(item.UserScore);

            }

            /*revscore = scolist.AsQueryable().Sum();
            if (comList.Count != 0)
            {
                review.ReviewScore = revscore / comList.Count;
            }*/

            review.Comment = comList;
            //db.Reviews.Add(review);
            //db.SaveChanges();
            
            int rid = review.ReviewId;

            if (review == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details/" + id);
        }

        

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            review.UserId = User.Identity.Name;
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmId = new SelectList(db.ClsFilms, "FilmId", "FilmName", review.FilmId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewId,UserId,FilmId,ReviewTitle,PostDate,Description")] Review review)
        {
            if (ModelState.IsValid)
            {
                review.UserId = User.Identity.Name;
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(db.ClsFilms, "FilmId", "FilmName", review.FilmId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteComment(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment com = db.Comments.Find(id);
            if(com == null)
            {
                return HttpNotFound();
            }
            return View(com);
        }

        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(int id, int filmId)
        {
            Comment com = db.Comments.Find(id);
            db.Comments.Remove(com);
            db.SaveChanges();
            return RedirectToAction("Details/" + filmId);
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
