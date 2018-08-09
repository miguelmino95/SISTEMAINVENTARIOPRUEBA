using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaInventarios.Models;

namespace SistemaInventarios.Controllers
{    
    public class MaterialesController : Controller
    {
        inventariosEntities db = new inventariosEntities();
        
        // GET: Materiales
        public ActionResult Index()
            
        {
            var materiales = (from m in db.materiales select m).ToList();            
            return View(materiales);
        }

        // GET: Materiales/Details/5
        public ActionResult Details(int id)
        {
            var m = db.materiales.Find(id);
            return View(m);
        }

        // GET: Materiales/Create
        public ActionResult Create()
        {
            ViewBag.idtipo = new SelectList(db.tipo, "idTipo", "nombre");
            return View();
        }

        // POST: Materiales/Create
        [HttpPost]
        public ActionResult Create(materiales m)
        {
            
            try
            {
                // TODO: Add insert logic here
                db.materiales.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                
                return View();
            }
        }

        // GET: Materiales/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.idtipo = new SelectList(db.tipo, "idTipo", "nombre");
            materiales m = db.materiales.Find(id);            
            return View(m);
        }

        // POST: Materiales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            try
            {
                // TODO: Add update logic here
                ViewBag.idtipo = new SelectList(db.tipo, "idTipo", "nombre");
                materiales m = db.materiales.Find(id);
                UpdateModel(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Materiales/Delete/5
        public ActionResult Delete(int id)
        {
            var m = db.materiales.Find(id);
            return View(m);
        }

        // POST: Materiales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var m = db.materiales.Find(id);
                db.materiales.Remove(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /////////////// JSON //////////////////////////
        public JsonResult listarMateriales()
        {
            var listado = (from m in db.materiales
                                       select new MaterialesvalidacionModel
                                       {
                                           idMaterial = m.idMaterial,
                                           CodMaterial = m.CodMaterial,
                                           Descripcion = m.Descripcion
                                       }).ToList();

            return Json(listado, JsonRequestBehavior.AllowGet);

        } //end of listar
    }
}
