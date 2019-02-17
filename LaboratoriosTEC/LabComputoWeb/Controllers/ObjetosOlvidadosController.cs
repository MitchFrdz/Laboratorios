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
    public class ObjetosOlvidadosController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();

        // GET: ObjetosOlvidados
        public ActionResult Index()
        {
			//IEnumerable es el padre de todo eso, arreglos, listas, etc, etc,etc.
            IEnumerable<tblObjetosOlvidados> tblObjetosOlvidado = db.tblObjetosOlvidados.Include(t => t.tblLaboratorio);
            return View(tblObjetosOlvidado.ToList());
        }

        // GET: ObjetosOlvidados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblObjetosOlvidados tblObjetosOlvidado = db.tblObjetosOlvidados.Find(id);
            if (tblObjetosOlvidado == null)
            {
                return HttpNotFound();
            }
            return View(tblObjetosOlvidado);
        }

        // GET: ObjetosOlvidados/Create
        public ActionResult Create()
        {
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre");
            return View();
        }

        // POST: ObjetosOlvidados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ObjetosOlvidadosID,LaboratorioID,Nombre,Foto,Nota,Fecha")] tblObjetosOlvidados tblObjetosOlvidado)
        {
            if (ModelState.IsValid)
            {
                db.tblObjetosOlvidados.Add(tblObjetosOlvidado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblObjetosOlvidado.LaboratorioID);
            return View(tblObjetosOlvidado);
        }

        // GET: ObjetosOlvidados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblObjetosOlvidados tblObjetosOlvidado = db.tblObjetosOlvidados.Find(id);

            if (tblObjetosOlvidado == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblObjetosOlvidado.LaboratorioID);
            return View(tblObjetosOlvidado);
        }

        // POST: ObjetosOlvidados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ObjetosOlvidadosID,LaboratorioID,Nombre,Foto,Nota,Fecha")] tblObjetosOlvidados tblObjetosOlvidado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblObjetosOlvidado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LaboratorioID = new SelectList(db.tblLaboratorio, "LaboratorioID", "Nombre", tblObjetosOlvidado.LaboratorioID);
            return View(tblObjetosOlvidado);
        }

        // GET: ObjetosOlvidados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblObjetosOlvidados tblObjetosOlvidado = db.tblObjetosOlvidados.Find(id);
            if (tblObjetosOlvidado == null)
            {
                return HttpNotFound();
            }
            return View(tblObjetosOlvidado);
        }

        // POST: ObjetosOlvidados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblObjetosOlvidados tblObjetosOlvidado = db.tblObjetosOlvidados.Find(id);
            db.tblObjetosOlvidados.Remove(tblObjetosOlvidado);
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
