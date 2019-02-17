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
    public class UsuariosController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();

        // GET: Usuarios
        public ActionResult Index()
        {
            var tblUsuario = db.tblUsuario.Include(t => t.tblUsuario2).Include(t => t.tblUsuario3).Include(t => t.tblUsuario4);
            return View(tblUsuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo");
            ViewBag.DeletedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo");
            ViewBag.UpdatedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioID,Correo,Contraseña,Duracion,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,DeletedBy,DeletedDate")] tblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                db.tblUsuario.Add(tblUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.CreatedBy);
            ViewBag.DeletedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.DeletedBy);
            ViewBag.UpdatedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.UpdatedBy);
            return View(tblUsuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.CreatedBy);
            ViewBag.DeletedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.DeletedBy);
            ViewBag.UpdatedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.UpdatedBy);
            return View(tblUsuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioID,Correo,Contraseña,Duracion,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,DeletedBy,DeletedDate")] tblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.CreatedBy);
            ViewBag.DeletedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.DeletedBy);
            ViewBag.UpdatedBy = new SelectList(db.tblUsuario, "UsuarioID", "Correo", tblUsuario.UpdatedBy);
            return View(tblUsuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            db.tblUsuario.Remove(tblUsuario);
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
