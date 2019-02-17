using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabComputo.Data;

namespace LabComputoWeb.Controllers
{
    public class ClasesController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();

        // GET: Clases
        public ActionResult Index()
        {
            var tblClase = db.tblClase.Include(t => t.tblLaboratorio).Include(t => t.tblProfesor);
            return View(tblClase.ToList());
        }

        // GET: Clases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClase tblClase = db.tblClase.Find(id);
            if (tblClase == null)
            {
                return HttpNotFound();
            }
            return View(tblClase);
        }

        // GET: Clases/Create
        public ActionResult Create()
        {
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre");
            ViewBag.ProfesorID = new SelectList(db.tblProfesor, "ProfesorID", "Nombre");
            return View();
        }

        // POST: Clases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClaseID,LaboratorioID,ProfesorID,FechaApartado,Registro")] tblClase tblClase)
        {
            if (ModelState.IsValid)
            {
                db.tblClase.Add(tblClase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblClase.LaboratorioID);
            ViewBag.ProfesorID = new SelectList(db.tblProfesor, "ProfesorID", "Nombre", tblClase.ProfesorID);
            return View(tblClase);
        }

        // GET: Clases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClase tblClase = db.tblClase.Find(id);
            if (tblClase == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblClase.LaboratorioID);
            ViewBag.ProfesorID = new SelectList(db.tblProfesor, "ProfesorID", "Nombre", tblClase.ProfesorID);
            return View(tblClase);
        }

        // POST: Clases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClaseID,LaboratorioID,ProfesorID,FechaApartado,Registro")] tblClase tblClase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblClase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblClase.LaboratorioID);
            ViewBag.ProfesorID = new SelectList(db.tblProfesor, "ProfesorID", "Nombre", tblClase.ProfesorID);
            return View(tblClase);
        }

        // GET: Clases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClase tblClase = db.tblClase.Find(id);
            if (tblClase == null)
            {
                return HttpNotFound();
            }
            return View(tblClase);
        }

        // POST: Clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblClase tblClase = db.tblClase.Find(id);
            db.tblClase.Remove(tblClase);
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
