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
    public class ClsFilmsController : Controller
    {
        private ClsFilmContext db = new ClsFilmContext();

        // GET: ClsFilms
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.Name;
            var clsFilms = db.ClsFilms.Include(c => c.Director);
            return View(clsFilms.ToList());
        }

        // GET: ClsFilms/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.UserId = User.Identity.Name;
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClsFilm clsFilm = db.ClsFilms.Find(id);
            List<AddActor> ct = db.AddActors.Where(i => i.FilmId == id).ToList();

            foreach(AddActor mg in ct)
            {
                Actor act = db.Actors.Find(mg.ActorId);
                clsFilm.Cast.Add(act);
            }
            if (clsFilm == null)
            {
                return HttpNotFound();
            }
            return View(clsFilm);
        }

        // GET: ClsFilms/Create
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.Name;
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "FirstName");
            return View();
        }

        // POST: ClsFilms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmId,FilmName,Description,DirectorId,GenreName,ReleaseDate,AverageScore")] ClsFilm clsFilm)
        {
            if (ModelState.IsValid)
            {
                clsFilm.User = User.Identity.Name;
                db.ClsFilms.Add(clsFilm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "FirstName", clsFilm.DirectorId);
            return View(clsFilm);
        }

        // GET: ClsFilms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClsFilm clsFilm = db.ClsFilms.Find(id);
            if (clsFilm == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "FirstName", clsFilm.DirectorId);
            return View(clsFilm);
        }

        // POST: ClsFilms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmId,FilmName,Description,DirectorId,GenreName,ReleaseDate,AverageScore")] ClsFilm clsFilm)
        {

            if (ModelState.IsValid)
            {
                db.Entry(clsFilm).State = EntityState.Modified;
                clsFilm.User = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "FirstName", clsFilm.DirectorId);
            return View(clsFilm);
        }

        // GET: ClsFilms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClsFilm clsFilm = db.ClsFilms.Find(id);
            if (clsFilm == null)
            {
                return HttpNotFound();
            }
            return View(clsFilm);
        }

        // POST: ClsFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClsFilm clsFilm = db.ClsFilms.Find(id);
            db.ClsFilms.Remove(clsFilm);
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
