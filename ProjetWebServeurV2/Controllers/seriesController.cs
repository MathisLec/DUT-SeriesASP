using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetWebServeurV2;
using PagedList;

namespace ProjetWebServeurV2.Models
{
    public class seriesController : Controller
    {
        //private td_coursEntities db = new td_coursEntities();
        private info_mlecoeuvreIUTEntities db = new info_mlecoeuvreIUTEntities();


        // GET: series
        public ViewResult Index(string sortOrder,string currentFilter, string searchString, int? page )
        {
            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            /*On récupère toutes les séries et on les stockent dans une variable*/
            var series = from s in db.series select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                series = series.Where(s => s.title.StartsWith(searchString));
            }
            series = series.OrderBy(s => s.id);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(series.ToPagedList(pageNumber,pageSize));
        }

        // GET: series/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            series series = db.series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // GET: series/Create
        [Authorize(Roles = "Administrateurs")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: series/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,plot,imdb,poster,director,youtube_trailer,awards,year_start,year_end")] series series)
        {
            if (ModelState.IsValid)
            {
                db.series.Add(series);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(series);
        }

        // GET: series/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            series series = db.series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: series/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,plot,imdb,poster,director,youtube_trailer,awards,year_start,year_end")] series series)
        {
            if (ModelState.IsValid)
            {
                db.Entry(series).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(series);
        }

        // GET: series/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            series series = db.series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            series series = db.series.Find(id);
            db.series.Remove(series);
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
