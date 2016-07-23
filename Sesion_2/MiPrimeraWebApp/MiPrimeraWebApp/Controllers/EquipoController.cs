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
    public class EquipoController : Controller
    {
        private MiPrimeraWebAppContext db = new MiPrimeraWebAppContext();

        // GET: Equipo
        public ActionResult Index()
        {
            var equipoModels = db.EquipoModels.Include(e => e.Pais);
            return View(equipoModels.ToList());
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoModel equipoModel = db.EquipoModels.Find(id);
            if (equipoModel == null)
            {
                return HttpNotFound();
            }
            return View(equipoModel);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            ViewBag.IDPais = new SelectList(db.PaisModels, "IDPais", "Nombre");
            return View();
        }

        // POST: Equipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEquipo,Nombre,copas,IDPais")] EquipoModel equipoModel)
        {
            if (ModelState.IsValid)
            {
                db.EquipoModels.Add(equipoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPais = new SelectList(db.PaisModels, "IDPais", "Nombre", equipoModel.IDPais);
            return View(equipoModel);
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoModel equipoModel = db.EquipoModels.Find(id);
            if (equipoModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPais = new SelectList(db.PaisModels, "IDPais", "Nombre", equipoModel.IDPais);
            return View(equipoModel);
        }

        // POST: Equipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEquipo,Nombre,copas,IDPais")] EquipoModel equipoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPais = new SelectList(db.PaisModels, "IDPais", "Nombre", equipoModel.IDPais);
            return View(equipoModel);
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoModel equipoModel = db.EquipoModels.Find(id);
            if (equipoModel == null)
            {
                return HttpNotFound();
            }
            return View(equipoModel);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoModel equipoModel = db.EquipoModels.Find(id);
            db.EquipoModels.Remove(equipoModel);
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
