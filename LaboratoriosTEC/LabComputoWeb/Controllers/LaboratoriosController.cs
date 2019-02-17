using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabComputo.Data;

namespace LabComputoWeb.Views
{
    public class LaboratoriosController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();

        // GET: Laboratorios
        public ActionResult Index()
        {
            return View(db.tblLaboratorio.ToList());
        }

        // GET: Laboratorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLaboratorio tblLaboratorio = db.tblLaboratorio.Find(id);
            if (tblLaboratorio == null)
            {
                return HttpNotFound();
            }
            return View(tblLaboratorio);
        }

        // GET: Laboratorios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Laboratorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaboratorioID,Nombre,Capacidad,Edificio,Disponible")] tblLaboratorio tblLaboratorio)
        {
            if (ModelState.IsValid)
            {
                db.tblLaboratorio.Add(tblLaboratorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLaboratorio);
        }

        // GET: Laboratorios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLaboratorio tblLaboratorio = db.tblLaboratorio.Find(id);
            if (tblLaboratorio == null)
            {
                return HttpNotFound();
            }
            return View(tblLaboratorio);
        }

        // POST: Laboratorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaboratorioID,Nombre,Capacidad,Edificio,Disponible")] tblLaboratorio tblLaboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLaboratorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLaboratorio);
        }

        // GET: Laboratorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLaboratorio tblLaboratorio = db.tblLaboratorio.Find(id);
            if (tblLaboratorio == null)
            {
                return HttpNotFound();
            }
            return View(tblLaboratorio);
        }

        // POST: Laboratorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLaboratorio tblLaboratorio = db.tblLaboratorio.Find(id);
            db.tblLaboratorio.Remove(tblLaboratorio);
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
