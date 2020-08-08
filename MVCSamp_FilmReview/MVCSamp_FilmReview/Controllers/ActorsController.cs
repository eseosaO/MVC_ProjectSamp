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
    public class ActorsController : Controller
    {
        private ClsFilmContext db = new ClsFilmContext();

        // GET: Actors
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.Name;
            return View(db.Actors.ToList());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.UserId = User.Identity.Name;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Actor actor = db.Actors.Find(id); //Search for actor with given id
            List<AddActor> acm = db.AddActors.Where(i => i.ActorId == id).ToList(); //list to store the confirmed Actorid in AddActor list
            foreach (AddActor cka in acm)
            {
                ClsFilm film = db.ClsFilms.Find(cka.FilmId); //Find film with Actorid in AddActor list
                actor.FilmCastOn.Add(film); //Add film to the FilmCastOn list
            }

            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.Name;
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorId,FirstName,Surname,DateofBirth")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                actor.User = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            actor.User = User.Identity.Name;

            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorId,FirstName,Surname,DateofBirth")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                actor.User = User.Identity.Name;
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
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
