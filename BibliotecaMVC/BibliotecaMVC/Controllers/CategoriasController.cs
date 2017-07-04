using BibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Categorias.Add(model);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria model = _context.Categorias.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Categoria model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(model).State = 
                        System.Data.Entity.EntityState.Modified;

                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
