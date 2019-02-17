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
    public class ProfesoresController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();

        // GET: Profesores
        public ActionResult Index()
        {
            return View(db.tblProfesor.ToList());
        }

        // GET: Profesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProfesor tblProfesor = db.tblProfesor.Find(id);
            if (tblProfesor == null)
            {
                return HttpNotFound();
            }
            return View(tblProfesor);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfesorID,Nombre,NumeroControl,Correo,Telefono,FechaNac,Firma")] tblProfesor tblProfesor)
        {
            if (ModelState.IsValid)
            {
                db.tblProfesor.Add(tblProfesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblProfesor);
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProfesor tblProfesor = db.tblProfesor.Find(id);
            if (tblProfesor == null)
            {
                return HttpNotFound();
            }
            return View(tblProfesor);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfesorID,Nombre,NumeroControl,Correo,Telefono,FechaNac,Firma")] tblProfesor tblProfesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProfesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblProfesor);
        }

        // GET: Profesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProfesor tblProfesor = db.tblProfesor.Find(id);
            if (tblProfesor == null)
            {
                return HttpNotFound();
            }
            return View(tblProfesor);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProfesor tblProfesor = db.tblProfesor.Find(id);
            db.tblProfesor.Remove(tblProfesor);
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
