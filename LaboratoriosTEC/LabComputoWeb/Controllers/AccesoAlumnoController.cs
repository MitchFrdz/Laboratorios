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
    public class AccesoAlumnoController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();

        // GET: AccesoAlumno
        public ActionResult Index()
        {
            var tblAccesoAlumno = db.tblAccesoAlumno.Include(t => t.tblAlumno).Include(t => t.tblComputadora);
            return View(tblAccesoAlumno.ToList());
        }

        // GET: AccesoAlumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccesoAlumno tblAccesoAlumno = db.tblAccesoAlumno.Find(id);
            if (tblAccesoAlumno == null)
            {
                return HttpNotFound();
            }
            return View(tblAccesoAlumno);
        }

        // GET: AccesoAlumno/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoID = new SelectList(db.tblAlumno, "AlumnoID", "Nombre");
            ViewBag.ComputadoraID = new SelectList(db.tblComputadora, "ComputadoraID", "Nota");
            return View();
        }

        // POST: AccesoAlumno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccesoID,AlumnoID,ComputadoraID,Fecha,HoraE,HoraS")] tblAccesoAlumno tblAccesoAlumno)
        {
            if (ModelState.IsValid)
            {
                db.tblAccesoAlumno.Add(tblAccesoAlumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoID = new SelectList(db.tblAlumno, "AlumnoID", "Nombre", tblAccesoAlumno.AlumnoID);
            ViewBag.ComputadoraID = new SelectList(db.tblComputadora, "ComputadoraID", "Nota", tblAccesoAlumno.ComputadoraID);
            return View(tblAccesoAlumno);
        }

        // GET: AccesoAlumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccesoAlumno tblAccesoAlumno = db.tblAccesoAlumno.Find(id);
            if (tblAccesoAlumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoID = new SelectList(db.tblAlumno, "AlumnoID", "Nombre", tblAccesoAlumno.AlumnoID);
            ViewBag.ComputadoraID = new SelectList(db.tblComputadora, "ComputadoraID", "Nota", tblAccesoAlumno.ComputadoraID);
            return View(tblAccesoAlumno);
        }

        // POST: AccesoAlumno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccesoID,AlumnoID,ComputadoraID,Fecha,HoraE,HoraS")] tblAccesoAlumno tblAccesoAlumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAccesoAlumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoID = new SelectList(db.tblAlumno, "AlumnoID", "Nombre", tblAccesoAlumno.AlumnoID);
            ViewBag.ComputadoraID = new SelectList(db.tblComputadora, "ComputadoraID", "Nota", tblAccesoAlumno.ComputadoraID);
            return View(tblAccesoAlumno);
        }

        // GET: AccesoAlumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccesoAlumno tblAccesoAlumno = db.tblAccesoAlumno.Find(id);
            if (tblAccesoAlumno == null)
            {
                return HttpNotFound();
            }
            return View(tblAccesoAlumno);
        }

        // POST: AccesoAlumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAccesoAlumno tblAccesoAlumno = db.tblAccesoAlumno.Find(id);
            db.tblAccesoAlumno.Remove(tblAccesoAlumno);
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
