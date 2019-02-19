using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabComputo.Data;
using System.IO;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabComputoWeb.Controllers
{
    public class AlumnosController : Controller
    {
        private LaboratoriosDB db = new LaboratoriosDB();

        // GET: Alumnos
        public ActionResult Index()
        {
            return View(db.tblAlumno.ToList());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlumno tblAlumno = db.tblAlumno.Find(id);
            if (tblAlumno == null)
            {
                return HttpNotFound();
            }
            return View(tblAlumno);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UploadFileModel model)
        {
			// crear carpeta fisica si no existe
			try {
				Directory.CreateDirectory((Server.MapPath("~/uploads/" + model.Nombre)));
			}
			catch (Exception) { }
			// ver si si se envio algo
			if (model != null)
			{
				var fileName = Path.GetFileName(model.Files[0].FileName);
				// subir archivo 
				var path = Path.Combine(Server.MapPath("~/uploads/" + model.Nombre + Session["Path"]), fileName);
				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
				}
				model.Files[0].SaveAs(path);

				// crear objeto archivo
				//Archivo archivo = set(fileName, "a");
				tblAlumno alumno = new tblAlumno();
				alumno.Nombre = model.Nombre;
				alumno.NumeroControl = model.NumeroControl;
				alumno.Correo = model.Correo;
				alumno.Carrera = model.Carrera;
				alumno.FechaNac = model.FechaNac;
				alumno.Telefono = model.Telefono;
				alumno.Foto = path;
				// ver si ya existe en la base de datos y si no agregarlo
				if (!db.tblAlumno.Any(x => x.Foto == alumno.Foto))
				{
					if (ModelState.IsValid)
					{
						db.tblAlumno.Add(alumno);
						db.SaveChanges();
						return RedirectToAction("Index");
					}
				}
				
				//subir al catalogo
				//CU.Create("Subio archivo " + fileName + " en " + Session["UserName"] + Session["Path"].ToString(), Int32.Parse(Session["UserID"].ToString()), Int32.Parse(Session["IDAcceso"].ToString()));
			}
			else
				Session["Message"] = "No se detecto ningun archivo para subir";

			return View();//tblAlumno);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlumno tblAlumno = db.tblAlumno.Find(id);
            if (tblAlumno == null)
            {
                return HttpNotFound();
            }
            return View(tblAlumno);
        }

        // POST: Alumnos/Edit/5
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

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlumno tblAlumno = db.tblAlumno.Find(id);
            if (tblAlumno == null)
            {
                return HttpNotFound();
            }
            return View(tblAlumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAlumno tblAlumno = db.tblAlumno.Find(id);
            db.tblAlumno.Remove(tblAlumno);
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
