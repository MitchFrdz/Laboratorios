﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabComputo.Data;
using System.IO;

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
        public ActionResult Create( HttpPostedFileBase file)
        {
			// crear carpeta fisica si no existe
			try {/*
				Directory.CreateDirectory((Server.MapPath("~/uploads/" + tblAlumno.Nombre)));*/
			}
			catch (Exception) { }
			// ver si si se envio algo
			if (file != null)
			{/*
				var fileName = Path.GetFileName(file.FileName);
				// subir archivo 
				var path = Path.Combine(Server.MapPath("~/uploads/" + tblAlumno.Nombre + Session["Path"]), fileName);
				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
				}
				file.SaveAs(path);

				// crear objeto archivo
				//Archivo archivo = set(fileName, "a");

				// ver si ya existe en la base de datos y si no agregarlo
				if (!db.tblAlumno.Any(x => x.Foto == tblAlumno.Foto))
				{
					if (ModelState.IsValid)
					{
						db.tblAlumno.Add(tblAlumno);
						db.SaveChanges();
						return RedirectToAction("Index");
					}
				}
				*/
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
