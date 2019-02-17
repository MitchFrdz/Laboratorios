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
    public class ComputadorasController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();

        // GET: Computadoras
        public ActionResult Index()
        {
            var tblComputadora = db.tblComputadora.Include(t => t.tblLaboratorio);
            return View(tblComputadora.ToList());
        }

        // GET: Computadoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComputadora tblComputadora = db.tblComputadora.Find(id);
            if (tblComputadora == null)
            {
                return HttpNotFound();
            }
            return View(tblComputadora);
        }

        // GET: Computadoras/Create
        public ActionResult Create()
        {
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre");
            return View();
        }

        // POST: Computadoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComputadoraID,LaboratorioID,NumeroComputadora,Funciona,Nota")] tblComputadora tblComputadora)
        {
            if (ModelState.IsValid)
            {
                db.tblComputadora.Add(tblComputadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblComputadora.LaboratorioID);
            return View(tblComputadora);
        }

        // GET: Computadoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComputadora tblComputadora = db.tblComputadora.Find(id);
            if (tblComputadora == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblComputadora.LaboratorioID);
            return View(tblComputadora);
        }

        // POST: Computadoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComputadoraID,LaboratorioID,NumeroComputadora,Funciona,Nota")] tblComputadora tblComputadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblComputadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblComputadora.LaboratorioID);
            return View(tblComputadora);
        }

        // GET: Computadoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComputadora tblComputadora = db.tblComputadora.Find(id);
            if (tblComputadora == null)
            {
                return HttpNotFound();
            }
            return View(tblComputadora);
        }

        // POST: Computadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblComputadora tblComputadora = db.tblComputadora.Find(id);
            db.tblComputadora.Remove(tblComputadora);
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
