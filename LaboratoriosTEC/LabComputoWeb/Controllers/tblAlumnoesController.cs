using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabComputoWeb.entity;

namespace LabComputoWeb.Controllers
{
    public class tblAlumnoesController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();
        // GET: tblAlumnoes
        public ActionResult Index()
        {
            return View(db.tblAlumnoes.ToList());
        }

        // GET: tblAlumnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlumno tblAlumno = db.tblAlumnoes.Find(id);
            if (tblAlumno == null)
            {
                return HttpNotFound();
            }
            return View(tblAlumno);
        }

        // GET: tblAlumnoes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: tblAlumnoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlumnoID,Nombre,NumeroControl,Correo,Carrera,Foto,FechaNac,Telefono")] tblAlumno tblAlumno)
        {
            if (ModelState.IsValid)
            {
                db.tblAlumnoes.Add(tblAlumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAlumno);
        }

        // GET: tblAlumnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlumno tblAlumno = db.tblAlumnoes.Find(id);
            if (tblAlumno == null)
            {
                return HttpNotFound();
            }
            return View(tblAlumno);
        }

        // POST: tblAlumnoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlumnoID,Nombre,NumeroControl,Correo,Carrera,Foto,FechaNac,Telefono")] tblAlumno tblAlumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAlumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAlumno);
        }

        // GET: tblAlumnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlumno tblAlumno = db.tblAlumnoes.Find(id);
            if (tblAlumno == null)
            {
                return HttpNotFound();
            }
            return View(tblAlumno);
        }

        // POST: tblAlumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAlumno tblAlumno = db.tblAlumnoes.Find(id);
            db.tblAlumnoes.Remove(tblAlumno);
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
