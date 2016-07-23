using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiPrimeraWebApp.Models;

namespace MiPrimeraWebApp.Controllers
{
    public class PaisController : Controller
    {
        private MiPrimeraWebAppContext db = new MiPrimeraWebAppContext();

        // GET: Pais
        public ActionResult Index()
        {
            return View(db.PaisModels.ToList());
        }

        // GET: Pais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaisModel paisModel = db.PaisModels.Find(id);
            if (paisModel == null)
            {
                return HttpNotFound();
            }
            return View(paisModel);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPais,Nombre")] PaisModel paisModel)
        {
            if (ModelState.IsValid)
            {
                db.PaisModels.Add(paisModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paisModel);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaisModel paisModel = db.PaisModels.Find(id);
            if (paisModel == null)
            {
                return HttpNotFound();
            }
            return View(paisModel);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPais,Nombre")] PaisModel paisModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paisModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paisModel);
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaisModel paisModel = db.PaisModels.Find(id);
            if (paisModel == null)
            {
                return HttpNotFound();
            }
            return View(paisModel);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaisModel paisModel = db.PaisModels.Find(id);
            db.PaisModels.Remove(paisModel);
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
