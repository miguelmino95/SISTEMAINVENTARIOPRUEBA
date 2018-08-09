using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaInventarios.Models;

namespace SistemaInventarios.Controllers
{
    public class TipoMaterialesController : Controller
    {
        inventariosEntities db = new inventariosEntities();
        // GET: TipoMateriales
        public ActionResult Index()
        {
            var tipos = (from t in db.tipo select t).ToList();
            return View(tipos);
        }

        // GET: TipoMateriales/Details/5
        public ActionResult Details(int id)
        {
            var t = db.tipo.Find(id);
            return View(t);
        }

        // GET: TipoMateriales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoMateriales/Create
        [HttpPost]
        public ActionResult Create(tipo t)
        {
            try
            {
                // TODO: Add insert logic here
                db.tipo.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoMateriales/Edit/5
        public ActionResult Edit(int id)
        {
            tipo t = db.tipo.Find(id);
            return View(t);
        }

        // POST: TipoMateriales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            try
            {
                // TODO: Add update logic here
                tipo t = db.tipo.Find(id);
                UpdateModel(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoMateriales/Delete/5
        public ActionResult Delete(int id)
        {
            var t = db.tipo.Find(id);
            return View(t);
        }

        // POST: TipoMateriales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                tipo t = db.tipo.Find(id);
                db.tipo.Remove(t);
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
            var listadotipomaterial = (from t in db.tipo
                                     select new TipoMaterialvalidaModel
                                     {
                                         idTipo = t.idTipo,
                                         nombre = t.nombre,                                         
                                     }).ToList();

            return Json(listadotipomaterial, JsonRequestBehavior.AllowGet);

        } //end of listar

        public JsonResult eliminar(tipo id)
        {
            var tmaterial = db.tipo.Find(id.idTipo);
            db.tipo.Remove(tmaterial);
            db.SaveChanges();
            var sms = "se elimino correctamente";
            return Json(sms);
        } //end of eliminarinventario

        public JsonResult guardar(tipo t)
        {
            var sms = "ERROR AL GUARDAR";
            if (ModelState.IsValid)
            {
                db.tipo.Add(t);
                db.SaveChanges();
                sms = "SE GUARDÓ CORRECTAMENTE";
            }
            return Json(sms, JsonRequestBehavior.AllowGet);
        }
    } //end controller
}

