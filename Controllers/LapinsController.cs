using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AjaxLapin.Models;

namespace AjaxLapin.Controllers
{
    public class LapinsController : Controller
    {
        private lapinContext db = new lapinContext();

        // GET: Lapins
        public ActionResult Index()
        {
            return View(db.lapins.ToList());
        }
        public JsonResult List()
        {
            return Json(db.lapins.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Lapin lpn)
        {
            db.lapins.Add(lpn);
            db.SaveChanges();
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int lpnID)
        {
            var lapin = db.lapins.ToList().Find(x => x.id.Equals(lpnID));
            return Json(lapin, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Lapin lpn)
        {
            Lapin l = db.lapins.Find(lpn.id);
            l.age = lpn.age;
            l.nomlapalin = lpn.nomlapalin;
            db.SaveChanges();
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            Lapin l = db.lapins.Find(id);
            db.lapins.Remove(l);
            db.SaveChanges();
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        // GET: Lapins/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Lapin lapin = db.lapins.Find(id);
        //    if (lapin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(lapin);
        //}

        // GET: Lapins/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Lapins/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,nomlapalin,age")] Lapin lapin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.lapins.Add(lapin);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(lapin);
        //}

        //// GET: Lapins/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Lapin lapin = db.lapins.Find(id);
        //    if (lapin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(lapin);
        //}

        //// POST: Lapins/Edit/5
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,nomlapalin,age")] Lapin lapin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(lapin).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(lapin);
        //}

        //// GET: Lapins/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Lapin lapin = db.lapins.Find(id);
        //    if (lapin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(lapin);
        //}

        //// POST: Lapins/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Lapin lapin = db.lapins.Find(id);
        //    db.lapins.Remove(lapin);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
