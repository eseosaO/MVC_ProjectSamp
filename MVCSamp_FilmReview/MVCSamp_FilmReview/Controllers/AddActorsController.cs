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
    public class AddActorsController : Controller
    {
        private ClsFilmContext db = new ClsFilmContext();

        // GET: AddActors
        public ActionResult Index()
        {
            var addActors = db.AddActors.Include(a => a.Actor).Include(a => a.Film);
            return View(addActors.ToList());
        }

        // GET: AddActors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddActor addActor = db.AddActors.Find(id);
            if (addActor == null)
            {
                return HttpNotFound();
            }
            return View(addActor);
        }

        // GET: AddActors/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName");
            ViewBag.FilmId = new SelectList(db.ClsFilms, "FilmId", "FilmName");
            return View();
        }

        // POST: AddActors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddActorId,FilmId,ActorId")] AddActor addActor)
        {
            if (ModelState.IsValid)
            {
                db.AddActors.Add(addActor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", addActor.ActorId);
            ViewBag.FilmId = new SelectList(db.ClsFilms, "FilmId", "FilmName", addActor.FilmId);
            return View(addActor);
        }

        // GET: AddActors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddActor addActor = db.AddActors.Find(id);
            if (addActor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", addActor.ActorId);
            ViewBag.FilmId = new SelectList(db.ClsFilms, "FilmId", "FilmName", addActor.FilmId);
            return View(addActor);
        }

        // POST: AddActors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddActorId,FilmId,ActorId")] AddActor addActor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", addActor.ActorId);
            ViewBag.FilmId = new SelectList(db.ClsFilms, "FilmId", "FilmName", addActor.FilmId);
            return View(addActor);
        }

        // GET: AddActors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddActor addActor = db.AddActors.Find(id);
            if (addActor == null)
            {
                return HttpNotFound();
            }
            return View(addActor);
        }

        // POST: AddActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddActor addActor = db.AddActors.Find(id);
            db.AddActors.Remove(addActor);
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
