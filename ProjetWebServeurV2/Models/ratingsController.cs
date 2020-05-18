using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetWebServeurV2;

namespace ProjetWebServeurV2.Models
{
    public class ratingsController : Controller
    {
        private td_coursEntities db = new td_coursEntities();

        // GET: ratings
        public ActionResult Index()
        {
            var rating = db.rating.Include(r => r.series).Include(r => r.user);
            return View(rating.ToList());
        }

        // GET: ratings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rating rating = db.rating.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // GET: ratings/Create
        public ActionResult Create()
        {
            ViewBag.series_id = new SelectList(db.series, "id", "title");
            ViewBag.user_id = new SelectList(db.user, "id", "name");
            return View();
        }

        // POST: ratings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,series_id,user_id,value,comment")] rating rating)
        {
            if (ModelState.IsValid)
            {
                db.rating.Add(rating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.series_id = new SelectList(db.series, "id", "title", rating.series_id);
            ViewBag.user_id = new SelectList(db.user, "id", "name", rating.user_id);
            return View(rating);
        }

        // GET: ratings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rating rating = db.rating.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            ViewBag.series_id = new SelectList(db.series, "id", "title", rating.series_id);
            ViewBag.user_id = new SelectList(db.user, "id", "name", rating.user_id);
            return View(rating);
        }

        // POST: ratings/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,series_id,user_id,value,comment")] rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.series_id = new SelectList(db.series, "id", "title", rating.series_id);
            ViewBag.user_id = new SelectList(db.user, "id", "name", rating.user_id);
            return View(rating);
        }

        // GET: ratings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rating rating = db.rating.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // POST: ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rating rating = db.rating.Find(id);
            db.rating.Remove(rating);
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
