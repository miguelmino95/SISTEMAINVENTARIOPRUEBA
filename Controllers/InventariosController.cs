using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaInventarios.Models;

namespace SistemaInventarios.Controllers
{
    public class InventariosController : Controller
    {
        inventariosEntities db = new inventariosEntities();
        // GET: Inventarios
        public ActionResult Index()
        {
            var inventario = (from i in db.inventario select i).ToList();
            return View(inventario);
        }

        // GET: Inventarios/Details/5
        public ActionResult Details(int id)
        {
            var i = db.inventario.Find(id);
            return View(i);
        }

        // GET: Inventarios/Create
        public ActionResult Create()
        {
            ViewBag.idMaterial = new SelectList(db.materiales, "idMaterial", "Descripcion");
            ViewBag.idTipoEstado = new SelectList(db.tipoestado, "idTipoEstado", "Descripcion");
            return View();
        }

        // POST: Inventarios/Create
        [HttpPost]
        public ActionResult Create(inventario i)
        {
            try
            {
                // TODO: Add insert logic here
                ViewBag.idMaterial = new SelectList(db.materiales, "idMaterial", "Descripcion");
                ViewBag.idTipoEstado = new SelectList(db.tipoestado, "idTipoEstado", "Descripcion");
                db.inventario.Add(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventarios/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.idMaterial = new SelectList(db.materiales, "idMaterial", "Descripcion");
            ViewBag.idTipoEstado = new SelectList(db.tipoestado, "idTipoEstado", "Descripcion");
            inventario i = db.inventario.Find(id);
            return View(i);
        }

        // POST: Inventarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            try
            {
                // TODO: Add update logic here
                ViewBag.idMaterial = new SelectList(db.materiales, "idMaterial", "Descripcion");
                ViewBag.idTipoEstado = new SelectList(db.tipoestado, "idTipoEstado", "Descripcion");
                inventario i = db.inventario.Find(id);
                UpdateModel(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventarios/Delete/5
        public ActionResult Delete(int id)
        {
            var i = db.inventario.Find(id);
            return View(i);
        }

        // POST: Inventarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var i = db.inventario.Find(id);
                db.inventario.Remove(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult listar()
        {
            var listadoinventario = (from i in db.inventario
                                     select new InventariosvalidaModel { idinventario = i.idinventario, 
                                     idMaterial = i.idMaterial, cantidad = i.cantidad, idTipoEstado = i.idTipoEstado }).ToList();

            return Json(listadoinventario, JsonRequestBehavior.AllowGet);

        } //end of listar

        public JsonResult eliminarinventario (inventario idinventario)
        {
            var id = db.inventario.Find(idinventario.idinventario);
            db.inventario.Remove(id);
            db.SaveChanges();
            var sms = "se elimino correctamente";
            return Json (sms);
        } //end of eliminarinventario

        public JsonResult guardarinventario (inventario i)
        {
            var sms = "ERROR AL GUARDAR";
            if (ModelState.IsValid)
            {
                db.inventario.Add(i);
                db.SaveChanges();
                sms = "SE GUARDÓ CORRECTAMENTE";
            }
            return Json(sms, JsonRequestBehavior.AllowGet);
        }
    } //end controller
}
