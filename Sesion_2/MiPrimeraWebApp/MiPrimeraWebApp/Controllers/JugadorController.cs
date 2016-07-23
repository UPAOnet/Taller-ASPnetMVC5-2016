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
    public class JugadorController : Controller
    {
        private MiPrimeraWebAppContext db = new MiPrimeraWebAppContext();

        // GET: Jugador
        public ActionResult Index()
        {
            var jugadorModels = db.JugadorModels.Include(j => j.Equipo);
            return View(jugadorModels.ToList());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorModel jugadorModel = db.JugadorModels.Find(id);
            if (jugadorModel == null)
            {
                return HttpNotFound();
            }
            return View(jugadorModel);
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            ViewBag.IDEquipo = new SelectList(db.EquipoModels, "IDEquipo", "Nombre");
            return View();
        }

        // POST: Jugador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDJugador,Nombre,Edad,Posicion,Estatura,IDEquipo")] JugadorModel jugadorModel)
        {
            if (ModelState.IsValid)
            {
                db.JugadorModels.Add(jugadorModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEquipo = new SelectList(db.EquipoModels, "IDEquipo", "Nombre", jugadorModel.IDEquipo);
            return View(jugadorModel);
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorModel jugadorModel = db.JugadorModels.Find(id);
            if (jugadorModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEquipo = new SelectList(db.EquipoModels, "IDEquipo", "Nombre", jugadorModel.IDEquipo);
            return View(jugadorModel);
        }

        // POST: Jugador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDJugador,Nombre,Edad,Posicion,Estatura,IDEquipo")] JugadorModel jugadorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugadorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEquipo = new SelectList(db.EquipoModels, "IDEquipo", "Nombre", jugadorModel.IDEquipo);
            return View(jugadorModel);
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorModel jugadorModel = db.JugadorModels.Find(id);
            if (jugadorModel == null)
            {
                return HttpNotFound();
            }
            return View(jugadorModel);
        }

        // POST: Jugador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JugadorModel jugadorModel = db.JugadorModels.Find(id);
            db.JugadorModels.Remove(jugadorModel);
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
